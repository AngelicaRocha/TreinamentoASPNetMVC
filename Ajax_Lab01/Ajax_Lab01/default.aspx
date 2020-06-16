<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Ajax_Lab01._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Aula de Ajax</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>ASP.Net - Chat</h1>
        <asp:Label ID="errorLabel" Visible="false" CssClass="erro" runat="server"></asp:Label>
        <asp:MultiView ID="MultiView1" ActiveViewIndex="1" runat="server">
            <asp:View ID="View1" runat="server">
                <section>
                    <asp:Label CssClass="legenda" runat="server" Text="Insira seu nome"></asp:Label>
                    <asp:TextBox CssClass="campo" runat="server" ID="nomeTextBox"></asp:TextBox>
                    <asp:Button CssClass="botao" runat="server" Text="Entrar no chat" ID="entrarButton" OnClick/>
                    <asp:Label runat="server" ID="mensagemLabel"></asp:Label>
                </section>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <section id="chat">
                    <asp:Label runat="server" CssClass="legenda" ID="digiteMensagemLabel"> Digite sua mensagem </asp:Label>
                    <asp:TextBox runat="server" CssClass="campo" TextMode="MultiLine" Rows="3" ID="mensagemTextBox"></asp:TextBox>
                    <asp:Button runat="server" CssClass="botao" Text="Enviar Mensagem" ID="enviarMensagemButton"/>
                    <asp:Button runat="server" CssClass="botao" Text="Sair" ID="sairButton" />
                    <div class="chat-box">
                        <asp:Repeater runat="server" ID="chatRepeater" ItemType="Lab_01.Models.ChatMensagem">
                            <ItemTemplate>
                                <div class='chat-mensagem-box'>
                                    <div class='chat-mensagem-participante'>
                                        <%# Item.DataHora.ToLongTimeString() %>
                                        <%# Item.Participante %>:
                                    </div>
                                    <div class="chat-mensagem-texto">
                                        <%# Item.Mensagem %>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </section>
            </asp:View>    
        </asp:MultiView>
    </form>
</body>
</html>
