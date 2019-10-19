<%@ Page Title="" Language="C#" MasterPageFile="~/admin/MasterAdmin.master" AutoEventWireup="true" CodeFile="catalog.aspx.cs" Inherits="admin_Default2" ValidateRequest="false" %>
<%@ Register TagPrefix="spaw" Namespace="Solmetra.Spaw2" Assembly="Solmetra.Spaw2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style1
    {
        height: 24px;
    }
    .style2
    {
        height: 23px;
    }
        .style3
        {
        }
        .style4
        {
            width: 109px;
            height: 12px;
        }
        .style5
        {
            height: 12px;
        }
        .style6
        {
            height: 104px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<b>Каталог</b>

                <table>
                <tr valign="top">
                <td>
            <asp:ListBox ID="ListBox1" runat="server" Height="300px" Width="240px" 
                AutoPostBack="True" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
            
                    <br />
            
                <asp:Button ID="Button_Add" runat="server" Text="Добавить товар" 
                    onclick="Button_Add_Click" Width="236px" />
            
                    <br />
                                  <asp:Button ID="Button_Remove" Width="236px" runat="server" Text="Удалить товар" 
                            onclick="Button_Remove_Click" />
                            <br />
                                <asp:Button ID="Topic_Save" runat="server" Text="Сохранить изменения" 
                                    onclick="Topic_Save_Click" Width="236px" />
            
        </td>
        <td class="style2">
        
        </td>
        <td>
            <asp:Panel ID="Panel2" Visible = "false" runat="server">
            
            <h4>Редактирование модели</h4>
                       
                    <table>
                        <tr>
                            <td class="style3">
                                Наименование</td>
                            <td>
                                <asp:TextBox ID="Tovar_Caption" runat="server" Width="225px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                
                                Цена</td>
                            <td>
                                <asp:TextBox ID="TB_Price" runat="server" Width="227px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                
                                Количество на складе</td>
                            <td>
                                <asp:TextBox ID="tbKol" runat="server" Width="227px"></asp:TextBox>
                            </td>
                        </tr> 
                        <tr>
                            <td class="style3">
                                
                                Краткое описание</td>
                            <td>
                                <asp:TextBox ID="tbText" runat="server" TextMode="MultiLine" Height="130px" Width="227px"></asp:TextBox>
                            </td>
                        </tr>                          
                        <tr>
                            <td class="style3">
                                
                                Раздел</td>
                            <td>
                                <asp:DropDownList ID="DDL_Section" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>                                               
                        <tr>
                            <td>
                                Картинка модели
                            </td>
                            <td>
                                <asp:Image ID="Image1" runat="server" Visible="False" /><br />
                                <asp:FileUpload ID="FileUpload2" runat="server" />
                            </td>
                        </tr>                        
                        <tr>
                            <td class="style3">
                                
                                Фотографии
                                
                            </td>
                            <td>
            <asp:FileUpload ID="FileUpload1" runat="server" Width="216px" />
            <asp:Button ID="Button1" runat="server"
                Text="Добавить" onclick="Button1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="2">
                                
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="style6" colspan="2">
                                
                                <asp:Panel ID="Panel1" runat="server" Height="97px" Visible="False" 
                                    Width="274px">
                                    Подпись&nbsp;&nbsp;
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    <br />
                                    <br />
                                    <asp:Button ID="Btn_Remove_foto" runat="server" onclick="Btn_Remove_foto_Click" 
                                        Text="Удалить фото" Width="175px" />
                                    &nbsp;
                                    <asp:Button ID="Save_foto" runat="server" onclick="Save_foto_Click" 
                                        Text="Сохранить подпись" Width="175px" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="style3">
                                
                            </td>
                            <td>
                                  &nbsp;</td>
                        </tr>
                        
                        </table>
                        
      
                  
              </td>
          </tr>
      </table>
          
      <div style="width: 100%; border-top: 2px solid black; margin: 20px 0;">
        Текст для выбранного товара
      </div>
    <spaw:Editor ID="spaw1" runat="server" Height="230px">
    </spaw:Editor>         
         
  </asp:Panel>   

                                

</asp:Content>

