﻿function checkUser(e){
    Console.log("hi");
    e.preventDefault(); 
    const Nickname = $("input[name='Nickname']").val();
    if (Nickname.length == 0) {
        alert("Enter Nickname");
        return;
    }
    /*var regexp = /[а-яё]/i;
    if (regexp.test(Nickname)) {
        alert("Invalid Nickname");
        return;
    }*/
    //const RealName = $("input[name='RealName']").val();
    //regexp = /^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$/g;
    //if (!regexp.test(RealName)) {
    //    alert("Invalid RealName");
    //    return;
    //}
    const Password = $("input[name='PassHash']").val();
    const RePassword = $("input[name='RePassword']").val();
    Console.log("pass: "+Password+"repass: "+RePassword)
    if (Password != RePassword) {
        alert("Password didn't mutch");
        return;
    }
    e.target.closest("form").submit();
});