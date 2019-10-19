<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="loginadmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Аутентификация</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
    <div style="height:300px;"></div>
        <div style="margin: 0 auto; width:300px; text-align:left;">
            <table>
                <tr>
                    <td>
                        Логин
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Login" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Пароль
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox_Pass" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        
                    </td>
                    <td>
                        <asp:Button ID="Button_Send" runat="server" Text="Войти" 
                            onclick="Button_Send_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
