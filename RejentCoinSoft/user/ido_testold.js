////////////////////////////////////////////////////////////////
/// IDO Code Start   
//////////////////////////////////////////////////////////////////////////////////////////////
const idoContractAbi = [{"inputs":[],"stateMutability":"nonpayable","type":"constructor"},{"anonymous":false,"inputs":[{"indexed":false,"internalType":"address","name":"user","type":"address"},{"indexed":false,"internalType":"uint256","name":"tariff","type":"uint256"},{"indexed":false,"internalType":"uint256","name":"amount","type":"uint256"}],"name":"DepositAt","type":"event"},{"anonymous":false,"inputs":[{"indexed":false,"internalType":"address","name":"","type":"address"}],"name":"OwnershipTransferred","type":"event"},{"anonymous":false,"inputs":[{"indexed":false,"internalType":"address","name":"user","type":"address"},{"indexed":false,"internalType":"uint256","name":"amount","type":"uint256"}],"name":"Withdraw","type":"event"},{"anonymous":false,"inputs":[{"indexed":false,"internalType":"address","name":"user","type":"address"},{"indexed":false,"internalType":"uint256","name":"amount","type":"uint256"},{"indexed":false,"internalType":"uint256","name":"withdrawnAt","type":"uint256"},{"indexed":false,"internalType":"uint256","name":"plan","type":"uint256"}],"name":"WithdrawPrincipal","type":"event"},{"inputs":[{"internalType":"bool","name":"_depositStatus","type":"bool"}],"name":"changeDepositStatus","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"contractAddr","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"uint256","name":"tariff","type":"uint256"},{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"deposit","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"depositStatus","outputs":[{"internalType":"bool","name":"","type":"bool"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"","type":"address"}],"name":"investors","outputs":[{"internalType":"bool","name":"registered","type":"bool"},{"internalType":"uint256","name":"invested","type":"uint256"},{"internalType":"uint256","name":"paidAt","type":"uint256"},{"internalType":"uint256","name":"withdrawn","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"owner","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"addr","type":"address"}],"name":"packageDetails","outputs":[{"internalType":"bool","name":"isRegsitered","type":"bool"},{"internalType":"uint256[]","name":"packageAmt","type":"uint256[]"},{"internalType":"uint256[]","name":"planType","type":"uint256[]"},{"internalType":"uint256[]","name":"purchaseAt","type":"uint256[]"},{"internalType":"uint256[]","name":"withdrawnPrincipalAmt","type":"uint256[]"},{"internalType":"uint256[]","name":"withdrawnPrincipalAt","type":"uint256[]"},{"internalType":"uint256[]","name":"nextWithdrawnPrincipalAt","type":"uint256[]"},{"internalType":"bool[]","name":"withdrawBtn","type":"bool[]"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"uint256","name":"","type":"uint256"}],"name":"tariffs","outputs":[{"internalType":"uint256","name":"time","type":"uint256"},{"internalType":"uint256","name":"percent","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"token","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"totalInvested","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"totalInvestors","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"totalWithdrawal","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"to","type":"address"}],"name":"transferOwnership","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"withdrawMint","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"uint256","name":"index","type":"uint256"}],"name":"withdrawPrincipal","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"user","type":"address"}],"name":"withdrawableMint","outputs":[{"internalType":"uint256","name":"amount","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address payable","name":"to","type":"address"},{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"withdrawalToAddress","outputs":[],"stateMutability":"nonpayable","type":"function"}];


const idoContractAddr = '0xA9d1D0cdB69c0Cf07Be805d5eAd213121c958A8D';


const busd_abi = [{"inputs":[],"payable":false,"stateMutability":"nonpayable","type":"constructor"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"owner","type":"address"},{"indexed":true,"internalType":"address","name":"spender","type":"address"},{"indexed":false,"internalType":"uint256","name":"value","type":"uint256"}],"name":"Approval","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"previousOwner","type":"address"},{"indexed":true,"internalType":"address","name":"newOwner","type":"address"}],"name":"OwnershipTransferred","type":"event"},{"anonymous":false,"inputs":[],"name":"Pause","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"from","type":"address"},{"indexed":true,"internalType":"address","name":"to","type":"address"},{"indexed":false,"internalType":"uint256","name":"value","type":"uint256"}],"name":"Transfer","type":"event"},{"anonymous":false,"inputs":[],"name":"Unpause","type":"event"},{"payable":true,"stateMutability":"payable","type":"fallback"},{"constant":true,"inputs":[{"internalType":"address","name":"owner","type":"address"},{"internalType":"address","name":"spender","type":"address"}],"name":"allowance","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"internalType":"address","name":"spender","type":"address"},{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"approve","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[{"internalType":"address","name":"account","type":"address"}],"name":"balanceOf","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"internalType":"uint256","name":"_amount","type":"uint256"}],"name":"burn","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"decimals","outputs":[{"internalType":"uint8","name":"","type":"uint8"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"internalType":"address","name":"spender","type":"address"},{"internalType":"uint256","name":"subtractedValue","type":"uint256"}],"name":"decreaseAllowance","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"getBurnedAmountTotal","outputs":[{"internalType":"uint256","name":"_amount","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"internalType":"address","name":"spender","type":"address"},{"internalType":"uint256","name":"addedValue","type":"uint256"}],"name":"increaseAllowance","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"isOwner","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"name","outputs":[{"internalType":"string","name":"","type":"string"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"owner","outputs":[{"internalType":"address","name":"","type":"address"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[],"name":"pause","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"paused","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[],"name":"renounceOwnership","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":true,"inputs":[],"name":"symbol","outputs":[{"internalType":"string","name":"","type":"string"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":true,"inputs":[],"name":"totalSupply","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"payable":false,"stateMutability":"view","type":"function"},{"constant":false,"inputs":[{"internalType":"address","name":"_receiver","type":"address"},{"internalType":"uint256","name":"_amount","type":"uint256"}],"name":"transfer","outputs":[{"internalType":"bool","name":"success","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":false,"inputs":[{"internalType":"address","name":"_from","type":"address"},{"internalType":"address","name":"_receiver","type":"address"},{"internalType":"uint256","name":"_amount","type":"uint256"}],"name":"transferFrom","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":false,"inputs":[{"internalType":"address","name":"newOwner","type":"address"}],"name":"transferOwnership","outputs":[],"payable":false,"stateMutability":"nonpayable","type":"function"},{"constant":false,"inputs":[],"name":"unpause","outputs":[{"internalType":"bool","name":"","type":"bool"}],"payable":false,"stateMutability":"nonpayable","type":"function"}];
const busd_addr = '0x913aFbBA462d6ae230344209d0Bd11CE3CE92Ed1';


/*
Bsc Mainnet - 56
Bsc Testnet - 97
*/
const fixChainId = 56;
var currentTokenPrice = 1;


/*
Bsc Mainnet - https://bscscan.com/
Bsc Testnet - https://testnet.bscscan.com/
*/
const baseExplorerUrl = "https://bscscan.com/";

const chainName = "Bsc Mainnet";


const deposit2= async (getPlanId,getThis) => {
	console.log("getPlanId",getPlanId);

    //alert(getThis);
	const { ethereum } = window;
	 
	/* var currentUrl = window.location.href;
	var splitExp = currentUrl.split("?");
	var referralCode = splitExp[1]; */



	accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	 $("#show_wall_addr").html(accounts[0]);
	var chainId = await ethereum.request({ method: 'eth_chainId' });

		//chainId = parseInt(chainId, 56);
	
		if(chainId!=fixChainId){
			$.toast({
            heading: 'Error',
            text: "Please select Binance Smart Chain",
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });

		     
			 
			return false;
			
		}
		
		
		
		
		//let inputAmt = $(getThis).prev().children().val();
    let inputAmt=  getThis;
		if(inputAmt < 50){
			alert("Minimum Limit 50");
			return false;
		}
				
		var weiAmt = 1000000000000000000*inputAmt;
		var hexaDecimal =  "0x"+weiAmt.toString(16);
    //alert(inputAmt);
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);
	
	// var Token = new web3.eth.Contract(busd_abi, busd_addr);
	var Trade = new web3.eth.Contract(idoContractAbi, idoContractAddr);

	
			Trade.methods.deposit(getPlanId ,hexaDecimal).send({from:userAddr},function(err,result){
            
				if(err!==null){
				    $.toast({
            heading: 'Error',
            text: err,
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });

				
				}
				else {
				   var ethShowLink = baseExplorerUrl+"tx/"+result;
				   $.toast({
                heading: 'Success',
                text: "View On <a target='_blank' href='"+ethShowLink+"' >BlockChain</a>",
                icon: 'success',
                hideAfter: 15000,
                showHideTransition : 'slide'  // It can be plain, fade or slide
            });
				    
				   
					 setTimeout(function(){ location.reload(); },15000);
				}
			})
}




const checkBusdAllowanceForIdoContract = async() => {
	
    accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	 $("#show_wall_addr").html(accounts[0]);
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);

	var Token = new web3.eth.Contract(busd_abi, busd_addr);
	
	//await Token.methods.allowance(userAddr, deposit_addr).call({from:userAddr},function(err,result){
	await Token.methods.allowance(userAddr, idoContractAddr).call({from:userAddr},function(err,result){
	    
	    if(result==0){
			console.log("allowance: ",result)
			$(".stake_now_amt").prop( "disabled", true );   
			$(".stake_now").html("Approve");    
            $(".stake_now").attr("onclick","approveBusd()");
	    }
	});
	
}




const idoClaimList = async() => { 

 accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	
	$("#show_wall_addr").html(accounts[0]);
	
	
	
	var chainId = await ethereum.request({ method: 'eth_chainId' });
	chainId = parseInt(chainId);
	if(chainId!=fixChainId){
		$.toast({
            heading: 'Error',
            text: "Please Select "+chainName+" Chain",
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });

		
        return false;
    }
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);
	
	var getBalance = await web3.eth.getBalance(userAddr);
	getBalance = getBalance / 10**18;
	getBalance  = getBalance.toFixed(4);
	$("#show_wall_addr_balance").html(getBalance);
	
	
	
	var Trade = new web3.eth.Contract(idoContractAbi,idoContractAddr);
	
	var setHtml = "";
	await Trade.methods.packageDetails(userAddr).call({from:userAddr},function(err,result){
		
		console.log("result",result);
		if(result['isRegsitered']== true){
			
			setInterval(function(){  roiData(); },2000);
			var htmlData = "<tr>";  
			for(i=0; i < result['packageAmt'].length; i++){
				
				var packageAmt = result['packageAmt'][i];
				packageAmt = packageAmt/(10**18);
				var planType = result['planType'][i];
				var withdrawnPrincipalAmt = result['withdrawnPrincipalAmt'][i];
				withdrawnPrincipalAmt = withdrawnPrincipalAmt/(10**18);
				var nextWithdrawnPrincipalAt = result['nextWithdrawnPrincipalAt'][i];
				if(nextWithdrawnPrincipalAt!=0) {
					var nextWithdrawnPrincipalAt = moment((nextWithdrawnPrincipalAt*1000));
					var nextWithdrawnPrincipalAt = nextWithdrawnPrincipalAt.format('MMMM Do YYYY, h:mm:ss A');
				}
				else {
					nextWithdrawnPrincipalAt="";
				}
				
				var withdrawnBtn = (result['withdrawBtn'][i]==true) ? "<button class='btn octf-btn-secondary ml-4' onClick='claimPrincipal("+i+");'>Claim</button>" : "";
				
				
				htmlData += "<tr>";  
				htmlData += "<td>"+(i+1)+"</td>";  
				htmlData += "<td> PLAN "+(parseInt(planType)+1)+"</td>";  
				htmlData += "<td>"+packageAmt+"</td>";  
				htmlData += "<td>"+withdrawnPrincipalAmt+"</td>";  
				htmlData += "<td>"+nextWithdrawnPrincipalAt+"</td>";
				htmlData += "<td>"+withdrawnBtn+"</td>";
				htmlData += "</tr>"; 
				
			}
			
			
			$("#set_kbody").html(htmlData);
			
			
		}
		
	});

	
	
}



const roiData = async() => { 

 accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	
	$("#show_wall_addr").html(accounts[0]);
	
	
	
	var chainId = await ethereum.request({ method: 'eth_chainId' });
	chainId = parseInt(chainId);
	if(chainId!=fixChainId){
		$.toast({
            heading: 'Error',
            text: "Please Select "+chainName+" Chain",
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });

		
        return false;
    }
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);
	
	var Trade = new web3.eth.Contract(idoContractAbi,idoContractAddr);
	
	var setHtml = "";
	await Trade.methods.withdrawableRoi(userAddr).call({from:userAddr},function(err,result){
		
			var roiAmount = result;
			roiAmount = roiAmount/(10**18);
			roiAmount = roiAmount.toFixed(8);

			$("#withdrawable_roi").html(roiAmount);
			
			
		
		
	});

	
	
}



const claimRoi = async() => {
	
	accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	$("#show_wall_addr").html(accounts[0]);
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);
    var chainId = await ethereum.request({ method: 'eth_chainId' });

    //chainId = parseInt(chainId, 56);

    //if(chainId!=322){
    if(chainId!=fixChainId){
    	$.toast({
            heading: 'Error',
            text: "Please Select "+chainName+" Chain",
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });

        
            
        return false;
        
    }
	var Trade = new web3.eth.Contract(idoContractAbi,idoContractAddr);
	Trade.methods.withdrawRoi().send({from:userAddr},function(err,result){
	    
		if(err!==null){
			$.toast({
            heading: 'Error',
            text: err,
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });

		    
			
		}
		else {
		   var ethShowLink = baseExplorerUrl+"tx/"+result;
		      $.toast({
                heading: 'Success',
                text: "View On <a target='_blank' href='"+ethShowLink+"' >BlockChain</a>",
                icon: 'success',
                hideAfter: 15000,
                showHideTransition : 'slide'  // It can be plain, fade or slide
            });
		     
		  
			// setTimeout(function(){ location.reload(); },15000);
		}
	})
}

const claimPrincipal = async(getIndex) => {
	
	accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	$("#show_wall_addr").html(accounts[0]);
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);
    var chainId = await ethereum.request({ method: 'eth_chainId' });

    //chainId = parseInt(chainId, 56);

    //if(chainId!=322){
    if(chainId!=fixChainId){
    	$.toast({
            heading: 'Error',
            text: "Please Select "+chainName+" Chain",
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });
         
            
        return false;
        
    }
	var Trade = new web3.eth.Contract(idoContractAbi,idoContractAddr);
	Trade.methods.withdrawPrincipal(getIndex).send({from:userAddr},function(err,result){
	    
		if(err!==null){
		    
		    $.toast({
            heading: 'Error',
            text: err,
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });
			
		}
		else {
		   var ethShowLink = baseExplorerUrl+"tx/"+result;
		   $.toast({
                heading: 'Success',
                text: "View On <a target='_blank' href='"+ethShowLink+"' >BlockChain</a>",
                icon: 'success',
                hideAfter: 15000,
                showHideTransition : 'slide'  // It can be plain, fade or slide
            });
		     
		  
			// setTimeout(function(){ location.reload(); },15000);
		}
	})
}





/////////////////////////////////////////////////////////////////////////////////////////////
/// IDO Code END
//////////////////////////////////////////////////////////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////////////////////
/// Metamas Connect Code Start
//////////////////////////////////////////////////////////////////////////////////////////////

//This will start the onboarding proccess
const onClickInstall2 = () => {
	onboardButton.innerText = 'Onboarding in progress';
	onboardButton.disabled = true;
	//On this object we have startOnboarding which will start the onboarding process for our end user
	onboarding.startOnboarding();
};

const onClickConnect2 = async () => {
	try {
		
		//Will Start the MetaMask Extension
		accounts = await ethereum.request({ method: 'eth_requestAccounts' });
		if(accounts[0]!= ''){
			$("#connect_wallet").html("Connected");  
		}
		
	} catch (error) {
		console.error(error);
	}
};
 
const isMetaMaskInstalled2 = () => {
	//Have to check the ethereum binding on the window object to see if it's installed
	const { ethereum } = window;
	
	return Boolean(ethereum && ethereum.isMetaMask);
}; 

const initialize2 = async() => {
	let accounts
	const isMetaMaskConnected = () => accounts && accounts.length > 0

	//Created check function to see if the MetaMask extension is installed
	const isMetaMaskInstalled2 = () => {
		//Have to check the ethereum binding on the window object to see if it's installed
		const { ethereum } = window;
		
		return Boolean(ethereum && ethereum.isMetaMask);
	};

	const MetamaskClientCheck = async() => {
	  //Now we check to see if Metmask is installed
	  if (!isMetaMaskInstalled2()) {
		//If it isn't installed we ask the user to click to install it
		//onboardButton.innerText = 'Click here to install MetaMask!';
		onClickInstall2();
	  } else if(!isMetaMaskConnected()) {
		//If MetaMask is installed we ask the user to connect to their wallet
		//onboardButton.innerText = 'Connect';
		onClickConnect2();
	  }

	};
	
	MetamaskClientCheck(); /// IDO Code END
	idoClaimList(); /// IDO Code END
	//roiData();
	
	checkBusdAllowanceForIdoContract(); /// IDO Code END
	
}

Number.prototype.toFixedNoRounding = function(n) {
    const reg = new RegExp("^-?\\d+(?:\\.\\d{0," + n + "})?", "g")
    const a = this.toString().match(reg)[0];
    const dot = a.indexOf(".");
    if (dot === -1) { // integer, insert decimal dot and pad up zeros
        return a + "." + "0".repeat(n);
    }
    const b = n - (a.length - dot) + 1;
    return b > 0 ? (a + "0".repeat(b)) : a;
 }
 window.addEventListener('DOMContentLoaded', initialize2)
/////////////////////////////////////////////////////////////////////////////////////////////
/// Metamask Connect Code End
//////////////////////////////////////////////////////////////////////////////////////////////



function copyToClipboard(){
	
	var linkHtml = $("#referral_link").html();
	
	if(linkHtml==" "){
		
		$.toast({
            heading: 'Error',
            text: "No Referral link Found",
            icon: 'error',
            hideAfter: 15000,
            showHideTransition : 'slide'  // It can be plain, fade or slide
            });
		return false;
	}
	var textArea = document.createElement("textarea");
	textArea.value = linkHtml;

	// Avoid scrolling to bottom
	textArea.style.top = "0";
	textArea.style.left = "0";
	textArea.style.position = "fixed";

	document.body.appendChild(textArea);
	textArea.focus();
	textArea.select();

	document.execCommand('copy');
	document.body.removeChild(textArea);
	
	$.toast({
                heading: 'Success',
                text: "Referral link Copied",
                icon: 'success',
                hideAfter: 15000,
                showHideTransition : 'slide'  // It can be plain, fade or slide
            });
			
}
