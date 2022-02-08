const forwarderOrigin = 'http://localhost:3005';
const contract_abi = [{ "inputs": [{ "internalType": "address", "name": "_token", "type": "address" }], "stateMutability": "nonpayable", "type": "constructor" }, { "anonymous": false, "inputs": [{ "indexed": false, "internalType": "address", "name": "", "type": "address" }, { "indexed": false, "internalType": "uint256", "name": "", "type": "uint256" }], "name": "Deposited", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": false, "internalType": "address", "name": "from", "type": "address" }, { "indexed": false, "internalType": "address", "name": "to", "type": "address" }], "name": "OwnershipTransferred", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": false, "internalType": "address", "name": "", "type": "address" }, { "indexed": false, "internalType": "uint256", "name": "", "type": "uint256" }], "name": "Received", "type": "event" }, { "inputs": [{ "internalType": "uint256", "name": "amount", "type": "uint256" }], "name": "deposit", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [], "name": "getOwner", "outputs": [{ "internalType": "address", "name": "", "type": "address" }], "stateMutability": "view", "type": "function" }, { "inputs": [], "name": "getWithdrawSetter", "outputs": [{ "internalType": "address", "name": "", "type": "address" }], "stateMutability": "view", "type": "function" }, { "inputs": [{ "internalType": "address", "name": "addr", "type": "address" }], "name": "setWithdrawSetter", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [{ "internalType": "address", "name": "to", "type": "address" }], "name": "transferOwnership", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [{ "internalType": "address", "name": "addr", "type": "address" }, { "internalType": "uint256", "name": "amount", "type": "uint256" }], "name": "updateWithdrawable", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [{ "internalType": "address", "name": "addr", "type": "address" }], "name": "viewWithdrawable", "outputs": [{ "internalType": "uint256", "name": "", "type": "uint256" }], "stateMutability": "view", "type": "function" }, { "inputs": [], "name": "withdraw", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [{ "internalType": "uint256", "name": "amount", "type": "uint256" }], "name": "withdrawBnb", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "inputs": [{ "internalType": "address", "name": "tokenAddress", "type": "address" }, { "internalType": "uint256", "name": "amount", "type": "uint256" }], "name": "withdrawToken", "outputs": [], "stateMutability": "nonpayable", "type": "function" }, { "stateMutability": "payable", "type": "receive" }]
const contract_addr = '0xC6008E8C28aBEAc352B9c653E98dB819DA3a0Ab7'
const token_addr = '0x913afbba462d6ae230344209d0bd11ce3ce92ed1'
const token_abi = [{ "inputs": [], "payable": false, "stateMutability": "nonpayable", "type": "constructor" }, { "anonymous": false, "inputs": [{ "indexed": true, "internalType": "address", "name": "owner", "type": "address" }, { "indexed": true, "internalType": "address", "name": "spender", "type": "address" }, { "indexed": false, "internalType": "uint256", "name": "value", "type": "uint256" }], "name": "Approval", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": true, "internalType": "address", "name": "previousOwner", "type": "address" }, { "indexed": true, "internalType": "address", "name": "newOwner", "type": "address" }], "name": "OwnershipTransferred", "type": "event" }, { "anonymous": false, "inputs": [], "name": "Pause", "type": "event" }, { "anonymous": false, "inputs": [{ "indexed": true, "internalType": "address", "name": "from", "type": "address" }, { "indexed": true, "internalType": "address", "name": "to", "type": "address" }, { "indexed": false, "internalType": "uint256", "name": "value", "type": "uint256" }], "name": "Transfer", "type": "event" }, { "anonymous": false, "inputs": [], "name": "Unpause", "type": "event" }, { "payable": true, "stateMutability": "payable", "type": "fallback" }, { "constant": true, "inputs": [{ "internalType": "address", "name": "owner", "type": "address" }, { "internalType": "address", "name": "spender", "type": "address" }], "name": "allowance", "outputs": [{ "internalType": "uint256", "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "internalType": "address", "name": "spender", "type": "address" }, { "internalType": "uint256", "name": "amount", "type": "uint256" }], "name": "approve", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [{ "internalType": "address", "name": "account", "type": "address" }], "name": "balanceOf", "outputs": [{ "internalType": "uint256", "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "internalType": "uint256", "name": "_amount", "type": "uint256" }], "name": "burn", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "decimals", "outputs": [{ "internalType": "uint8", "name": "", "type": "uint8" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "internalType": "address", "name": "spender", "type": "address" }, { "internalType": "uint256", "name": "subtractedValue", "type": "uint256" }], "name": "decreaseAllowance", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "getBurnedAmountTotal", "outputs": [{ "internalType": "uint256", "name": "_amount", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "internalType": "address", "name": "spender", "type": "address" }, { "internalType": "uint256", "name": "addedValue", "type": "uint256" }], "name": "increaseAllowance", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "isOwner", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "name", "outputs": [{ "internalType": "string", "name": "", "type": "string" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "owner", "outputs": [{ "internalType": "address", "name": "", "type": "address" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [], "name": "pause", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "paused", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [], "name": "renounceOwnership", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": true, "inputs": [], "name": "symbol", "outputs": [{ "internalType": "string", "name": "", "type": "string" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": true, "inputs": [], "name": "totalSupply", "outputs": [{ "internalType": "uint256", "name": "", "type": "uint256" }], "payable": false, "stateMutability": "view", "type": "function" }, { "constant": false, "inputs": [{ "internalType": "address", "name": "_receiver", "type": "address" }, { "internalType": "uint256", "name": "_amount", "type": "uint256" }], "name": "transfer", "outputs": [{ "internalType": "bool", "name": "success", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "internalType": "address", "name": "_from", "type": "address" }, { "internalType": "address", "name": "_receiver", "type": "address" }, { "internalType": "uint256", "name": "_amount", "type": "uint256" }], "name": "transferFrom", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [{ "internalType": "address", "name": "newOwner", "type": "address" }], "name": "transferOwnership", "outputs": [], "payable": false, "stateMutability": "nonpayable", "type": "function" }, { "constant": false, "inputs": [], "name": "unpause", "outputs": [{ "internalType": "bool", "name": "", "type": "bool" }], "payable": false, "stateMutability": "nonpayable", "type": "function" }]

///const contract_abi = [{"inputs":[{"internalType":"address","name":"_token","type":"address"}],"stateMutability":"nonpayable","type":"constructor"},{"anonymous":false,"inputs":[{"indexed":false,"internalType":"address","name":"","type":"address"},{"indexed":false,"internalType":"uint256","name":"","type":"uint256"}],"name":"Deposited","type":"event"},{"anonymous":false,"inputs":[{"indexed":false,"internalType":"address","name":"from","type":"address"},{"indexed":false,"internalType":"address","name":"to","type":"address"}],"name":"OwnershipTransferred","type":"event"},{"anonymous":false,"inputs":[{"indexed":false,"internalType":"address","name":"","type":"address"},{"indexed":false,"internalType":"uint256","name":"","type":"uint256"}],"name":"Received","type":"event"},{"inputs":[{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"deposit","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"getOwner","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"getWithdrawSetter","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"addr","type":"address"}],"name":"setWithdrawSetter","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"to","type":"address"}],"name":"transferOwnership","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"addr","type":"address"},{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"updateWithdrawable","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"addr","type":"address"}],"name":"viewWithdrawable","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"withdraw","outputs":[{"internalType":"bool","name":"","type":"bool"}],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"withdrawBnb","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"tokenAddress","type":"address"},{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"withdrawToken","outputs":[],"stateMutability":"nonpayable","type":"function"},{"stateMutability":"payable","type":"receive"}]
//const contract_addr = '0x7620a39162E51e7fa0D424FD024b22dc9A253Ffb'
///const token_addr = '0x72478b6F67364e73ebE93e979A8be3901EA9E5A0'
///const token_abi = [{"inputs":[],"stateMutability":"nonpayable","type":"constructor"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"_owner","type":"address"},{"indexed":true,"internalType":"address","name":"_spender","type":"address"},{"indexed":false,"internalType":"uint256","name":"_value","type":"uint256"}],"name":"Approval","type":"event"},{"anonymous":false,"inputs":[{"indexed":true,"internalType":"address","name":"_from","type":"address"},{"indexed":true,"internalType":"address","name":"_to","type":"address"},{"indexed":false,"internalType":"uint256","name":"_value","type":"uint256"}],"name":"Transfer","type":"event"},{"inputs":[{"internalType":"address","name":"_owner","type":"address"},{"internalType":"address","name":"_spender","type":"address"}],"name":"allowance","outputs":[{"internalType":"uint256","name":"remaining","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"_spender","type":"address"},{"internalType":"uint256","name":"_amount","type":"uint256"}],"name":"approve","outputs":[{"internalType":"bool","name":"success","type":"bool"}],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"_owner","type":"address"}],"name":"balanceOf","outputs":[{"internalType":"uint256","name":"balance","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"from","type":"address"},{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"burn","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address payable","name":"_newOwner","type":"address"}],"name":"changeOwnership","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"decimals","outputs":[{"internalType":"uint8","name":"","type":"uint8"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"to","type":"address"},{"internalType":"uint256","name":"amount","type":"uint256"}],"name":"mint","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"name","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"owner","outputs":[{"internalType":"address","name":"","type":"address"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"symbol","outputs":[{"internalType":"string","name":"","type":"string"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"totalSupply","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"address","name":"_to","type":"address"},{"internalType":"uint256","name":"_amount","type":"uint256"}],"name":"transfer","outputs":[{"internalType":"bool","name":"success","type":"bool"}],"stateMutability":"nonpayable","type":"function"},{"inputs":[{"internalType":"address","name":"_from","type":"address"},{"internalType":"address","name":"_to","type":"address"},{"internalType":"uint256","name":"_amount","type":"uint256"}],"name":"transferFrom","outputs":[{"internalType":"bool","name":"success","type":"bool"}],"stateMutability":"nonpayable","type":"function"}]
   
const isMetaMaskInstalled = () => {
	//Have to check the ethereum binding on the window object to see if it's installed
	const { ethereum } = window;
	
	return Boolean(ethereum && ethereum.isMetaMask);
};




const initialize = async() => {
	// let accounts
	// const isMetaMaskConnected = () => accounts && accounts.length > 0

	// //Created check function to see if the MetaMask extension is installed
	// const isMetaMaskInstalled = () => {
	// 	//Have to check the ethereum binding on the window object to see if it's installed
	// 	const { ethereum } = window;
		
	// 	return Boolean(ethereum && ethereum.isMetaMask);
	// };

	// const MetamaskClientCheck = async() => {
	//   //Now we check to see if Metmask is installed
	//   if (!isMetaMaskInstalled()) {
	// 	//If it isn't installed we ask the user to click to install it
	// 	//onboardButton.innerText = 'Click here to install MetaMask!';
	// 	onClickInstall();
	//   } else if(!isMetaMaskConnected()) {
	// 	//If MetaMask is installed we ask the user to connect to their wallet
	// 	//onboardButton.innerText = 'Connect';
	// 	///onClickConnect();
		
	//   }

	// };
	
	//const onboarding = new MetamaskOnboarding({ forwarderOrigin });
	///MetamaskClientCheck();
	checkAllowance();
	//myDeposits();
	///getCurrentBalance();
	///setInterval(function(){ checkAllowance(); },1000);
}
const checkAllowance = async() => {
	
    accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);

	var Token = new web3.eth.Contract(token_abi, token_addr);
	
	await Token.methods.allowance(userAddr, contract_addr).call({from:userAddr},function(err,result){
	    console.log(result);
	    if(result==0){
			$.ajaxSetup({
				headers: {
				'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
				}
			});
			var formData = "wallet_address="+userAddr;
			$.ajax({ 
				//url: "https://teamrijent.com/user/updateWallet",
				//data:formData,
				//type: 'POST',
				//success: function(result)
				//{ 
				//}
			});
			//$(".techWithdraw").attr('style', 'display: none !important');
			//$(".techDeposite").attr('style', 'display: none !important'); 
   //         $(".approveMeta").css("display","block");
	    }else{
			//$(".approveMeta").attr('style', 'display: none !important'); 			
		}
	});
	
}

//const approve = async() => {
//    accounts = await ethereum.request({ method: 'eth_requestAccounts' });
//	var userAddr = accounts[0];
//	//var web3 = new Web3(Web3.givenProvider);
//	var web3 = new Web3(window.web3.currentProvider);
//	var Token = new web3.eth.Contract(token_abi, token_addr);
	
//	var amt = 350000000000000000000000000;
//	var amount = "0x"+amt.toString(16);
	
//	await Token.methods.approve(contract_addr, amount).send({from:userAddr},function(err,result){
//	    if(err!==null){
//			//$.toast({
//			// 	heading: 'Error',
//			// 	text: err,
//			//	icon: 'error',
//			//	hideAfter: 15000,
//			// 	showHideTransition : 'slide'  // It can be plain, fade or slide
//			// });
//            toastr.error('Error', err);
//		}
//		else { 
//			setTimeout(function(){ location.reload(); },5000);
//		}
//	})
//}


const getCurrentBalance = async() => {
	accounts = await ethereum.request({ method: 'eth_requestAccounts' });
	var userAddr = accounts[0];
	//var web3 = new Web3(Web3.givenProvider);
	var web3 = new Web3(window.web3.currentProvider);
	var Token = new web3.eth.Contract(token_abi,token_addr);
	await Token.methods.balanceOf(userAddr).call({from:userAddr},function(err, result){
	    result = result/10**18;
    	$("#userBal").html(result);
	})
	
	
}
/*
const techWithdraw = async(data_otp) => {
	
   lock_status = 0;
//   data_otp = $(this).attr('data-otp');
   alert(data_otp);
   var withdrwalAmt = $("#withdrwalAmt").val();
   $(".techWithdraw").attr("disabled", true);
   
    if( withdrwalAmt > 0 ){
   	if(data_otp == 0){
   		$.ajax({ 
   			url:"/user/smart_withdrawal_otp_request",
   			type:'post',
   			data:{ _token : $('[name="_token"]').val()  , withdrwalAmt:withdrwalAmt},
   			dataType:'json',
   			success:function(data){ 
   				if(data.status == true){
   					$('#otp_modal').modal('show');
   				}else{
   					$('#otp_error_msg').html('<span style="color:red;">'+data.message+'</span>');
   				}
   			}
   		}); 
   	}else{
   		lock_status = 1;
   	} 
   	if(lock_status){
   		$('.loaderr').css({"display":"block"});
   		 var wallet = $("[name='deposite_withdrawal']:checked").val(); //added by jp
   		 var formData  = "withdrwalAmt="+withdrwalAmt;  
   		 $.ajax({ 
   			 url: "/user/withdrawalRequest",
   			 //data: formData,  //comment by jp 
   			 data: { withdrwalAmt : withdrwalAmt , wallet : wallet }  ,
   			 type: 'post',
   			 success: function(result)
   			 { 	 
   				var base_url = "https://teamrijent.com";	
   				 console.log(result); 
   				 if(result.type == 'verification')
   				 {
   					 location.assign(base_url+"user/mobile_verification");
   				 }
   				 else{
   					 alert(result.msg);
   				 }		 
   				
   				 if(result.type=='success'){ 
   					withdraw( result.withdrwalAmt , result.wallet );
   				 }
   				 $('.loaderr').css({"display":"none"});
   			 }
   		 });
   	}
   	 
      }else{
   	$(".techWithdraw").attr("disabled", false);
   	alert("Please amount must be grater than zero");
      }
       
      
   }
  */  


//This will start the onboarding proccess
const onClickInstall = () => {
	onboardButton.innerText = 'Onboarding in progress';
	onboardButton.disabled = true;
	//On this object we have startOnboarding which will start the onboarding process for our end user
	onboarding.startOnboarding();
};

//const onClickConnect = async () => {
//	try { 
//		//Will Start the MetaMask Extension 
//		wallet_address = await ethereum.request({ method: 'eth_requestAccounts' });
//		$.ajaxSetup({
//            headers: {
//            'X-CSRF-TOKEN': $('meta[name="csrf-token"]').attr('content')
//            }
//        });
//		var formData = "wallet_address="+wallet_address;
//        $.ajax({ 
//            //url: "https://teamrijent.com/user/updateWallet",
//            url: '../Webservices/SmartContract.asmx/UpdateWalletAddress',
//            data: "{ 'prefix': '" + formData + "'}",
//            dataType: "json",
//            type: 'POST',
//            contentType: "application/json; charset=utf-8",
//            success: function(result)
//            { 
//                alert(result.msg);
//                ///window.location.href = "https://teamrijent.com/user/index";
//            }
//        });
//        alert(formData);

		
//	} catch (error) {
//		alert("Please Login on Metamask Google Chrome Extensions");
//	}
//};
  

// window.addEventListener('DOMContentLoaded', initialize)