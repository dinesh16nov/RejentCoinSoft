var axios = require('axios');

var express=require('express');
var bodyParser = require('body-parser');
const BigNumber = require('bignumber.js');
var app=express();

app.use(bodyParser.urlencoded({extended: true}));
app.use(bodyParser.json());


const Web3 = require('web3');

const contractJson = require('./contract.json');
///Testnet
/*
var HttpProviderUrl   = "https://data-seed-prebsc-1-s1.binance.org:8545/";
const adminPrivKey = 'b0e4a2a81ba3234e8fe163082a422ae36a8abf59c78cb33353f74bbaa304c02e';
*/
////Mainnet
var HttpProviderUrl   = "https://bsc-dataseed.binance.org/";
const adminPrivKey = '47a72ea36822082b8c45c5d8fdb9c1c56ff79d325f7280b79c33b382f8a909cd';

const web3Bsc = new Web3(HttpProviderUrl);    

  
const { address: admin } = web3Bsc.eth.accounts.wallet.add(adminPrivKey);


const contractObj = new web3Bsc.eth.Contract(
  contractJson.abi,
  contractJson.contractAddress
);




app.get('/',function(req,res)
{
	//var getData = web3.eth.accounts.create();
	res.send('test');
});


app.get('/create', async function (req, res) {

  

    //var account = web3.eth.accounts.create();
    //return account;

    var getTxId = req.query.tx_id;
    var httpWeb3 = new Web3(new Web3.providers.HttpProvider(HttpProviderUrl));
    var txEthResp = await httpWeb3.eth.accounts.create();
    return res.send({ success: true, message: "Address Details", data: txEthResp });
    //return res.send({success:true,message:"Data updated",data:receipt.transactionHash});


});

app.post('/update_withdrawal',async function(req,res) { 

   
  var walletAddress = req.body.wallet_address;
    var amount = req.body.amount; 
    var adminprivatekey2 = req.body.adminprivatekeynew;

    const { address: admin2 } = web3Bsc.eth.accounts.wallet.add(adminprivatekey2);

  console.log(walletAddress);
  console.log(amount);
  amount = amount.toString(16);
  amount = "0x"+amount;
  var tx = contractObj.methods.updateWithdrawable(walletAddress,amount);
  const [gasPrice, gasCost] = await Promise.all([
      web3Bsc.eth.getGasPrice(),
      tx.estimateGas({from: admin2}),
      ]);
   const data = tx.encodeABI();
      const txData = {
      from: admin2,
      to: contractObj.options.address,
      data,
      gas: gasCost,
      gasPrice
      };
      
  //const receipt = await web3Bsc.eth.sendTransaction(txData)
    web3Bsc.eth.sendTransaction(txData)
        .on('transactionHash', function(hash){
          console.log(hash);
        }) 
        .on('receipt', function(receipt){
         /// console.log(receipt);
        })
        .on('confirmation', function(confirmationNumber, receipt){ 
          return res.send({success:true,message:"Data updated",data:receipt.transactionHash});
        })
        .on('error', function(error){
          return res.send({success:false,message:"Something Went Wrong",data:error});
        });
        
  //return res.send({success:true,message:"Data updated",data:receipt.transactionHash});
  

});

app.get("/getbalance", async function (req, res) {
    var walletaddress = req.query.useraddress;
    var httpWeb3 = new Web3(new Web3.providers.HttpProvider(HttpProviderUrl));
    var txEthResp = await httpWeb3.eth.getBalance(walletaddress);
    return res.send({ success: true, message: "User balance", data: txEthResp });
});

app.get("/tx_details",async function(req,res){
	var getTxId = req.query.tx_id;
	var httpWeb3 = new Web3(new Web3.providers.HttpProvider(HttpProviderUrl));
	var txEthResp = await httpWeb3.eth.getTransactionReceipt(getTxId);
	return res.send({success:true,message:"tx detail",data:txEthResp});
});

var server=app.listen(3005,function(){
	console.log("server started at port 3005");
	
});