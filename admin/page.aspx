<%@ Page Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="page.aspx.cs" Inherits="admin_page" Title="" ValidateRequest="false" %>
<%@ Register TagPrefix="spaw" Namespace="Solmetra.Spaw2" Assembly="Solmetra.Spaw2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <b>Страницы</b><br /><br />
                    <a href="page.aspx?name=main" style="color:Black;">Главная</a><br /><br /><br />
                    <a href="page.aspx?name=about" style="color:Black;">О компании</a><br /><br /><br />
                    <a href="page.aspx?name=find" style="color:Black;">Как нас найти</a><br /><br /><br />
                    <a href="page.aspx?name=discont" style="color:Black;">Наши скидки</a><br /><br /><br />
                    <a href="page.aspx?name=price" style="color:Black;">Прайс-лист</a><br /><br />
    
    <br /><br /><asp:Label ID="lblSC" runat="server" Text=""></asp:Label><br />
                        

                <br />
                
                
    <br />
    <spaw:Editor ID="spaw2" runat="server" Height="230px"><Pages>
<spaw:EditorPage ClientID="spaw2" Caption="spaw2"></spaw:EditorPage>
</Pages>
    </spaw:Editor>
    
<asp:Button ID="Topic_Save" runat="server" Text="Сохранить изменения" Width="175px" onclick="Topic_Save_Click" />    
</asp:Content>

