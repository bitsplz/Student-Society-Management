<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Test3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #LoginId {
            height: 30px;
            width: 200px;
            margin-left: 15px;
            margin-top: 40px;
        }
        #LoginPassword {
            height: 30px;
            width: 200px;
            margin-left: 15px;
            margin-top: 20px;
        }
        #LoginButton {
            height: 30px;
            width: 200px;
            margin-left: 15px;
            margin-top: 30px;
            border-radius:30px;
            background-color:green;
        }
        /*#TextBox1{
           margin-left: 170px;
            align-content:center;
            Width: 118px;
            font-weight:bold;
            Font-Size:Larger;
            Height:50px;
            background-color:darkred;
            bord
        }*/
        #Login{
            height: 300px; 
            width: 300px; 
            margin-left: 476px; 
            margin-right: 0px; 
            margin-top: 67px;
            border:solid 1px;
            text-align:center;
        }
        h4{
            font-family:'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
            font-size:larger;
            font-weight:bold;
            padding:10px;
            
        }
        #LoginBar{
            height: 50px; 
            width:300px; 
            margin-top: 21px;
            background-color:darkred;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Main">
            <div id="Login">
                <div id="LoginBar">
                    <h4>LOGIN</h4>
                </div>
                <input id="LoginId" type="text" />
                <input id="LoginPassword" type="password" />
                <input id="LoginButton" type="submit" value="LOGIN" /></div>
            
        </div>
    </form>
</body>
</html>
