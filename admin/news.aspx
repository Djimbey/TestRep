<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" ValidateRequest="false" %>
<%@ Register TagPrefix="spaw" Namespace="Solmetra.Spaw2" Assembly="Solmetra.Spaw2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 29px;
        }
        .style2
        {
            width: 13px;
        }
    .style3
    {
        width: 147px;
    }
    .style4
    {
        height: 29px;
        width: 147px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<b>Новости</b>

                <table>
                <tr valign="top">
                <td>
            <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="250px" 
                AutoPostBack="True" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            <p>
                <asp:Button ID="Button_Add" runat="server" Text="Добавить" 
                    onclick="Button_Add_Click" Width="150px" />
            </p>
            <p><asp:Button ID="Button_Remove" runat="server" Text="Удалить" 
                            onclick="Button_Remove_Click" Width="150px" />
            </p>
            <p><asp:Button ID="Topic_Save" runat="server" Text="Сохранить" 
                                    onclick="Topic_Save_Click" Width="150px" />
            </p>            
        </td>
        <td class="style2">
        
        </td>
        <td>
                    <table>
                        <tr>
                            <td class="style3">
                                Заголовок</td>
                            <td>
                                <asp:TextBox ID="TB_Title" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                Аннотация новости
                            </td>
                            <td>
                                <asp:TextBox ID="News_Annotation" runat="server" TextMode="MultiLine" Height="150" Width="254px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style4">
                                Дата публикации
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="News_DT" runat="server" Width="254px"></asp:TextBox>
                                &nbsp;
                                </td>
                        </tr>                
                        
                        </table>
              </td>
          </tr>
      </table>
                Текст         
                                
                <br />

    <spaw:Editor ID="spaw1" runat="server" Height="230px">
    </spaw:Editor>
    <br />
                   


</asp:Content>

