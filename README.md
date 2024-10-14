O projeto foi feito utilizando um banco de dados em memory para ser funcional criamos 4 endpoint para envio de notifica��es de coleta de lixo. 




Testando com Postman

Este guia explica como testar os endpoints da API utilizando o Postman. Certifique-se de substituir <port> pela porta configurada na sua aplica��o.

Gerar o Token JWT
Fa�a uma requisi��o POST para https://localhost:<port>/api/auth/login.
Copie o token JWT da resposta.

Enviar Notifica��o:
Fa�a uma requisi��o POST para https://localhost:<port>/api/notificacoes.
Adicione o cabe�alho Authorization com o valor Bearer <token>.

No corpo da requisi��o, adicione os dados da notifica��o no formato JSON:
{
  "titulo": "Notifica��o de Teste",
  "mensagem": "Esta � uma mensagem de teste",
  "dataEnvio": "2024-06-27T00:08:32.883Z",
  "enviada": true
}

Obter Notifica��es:
Fa�a uma requisi��o GET para https://localhost:<port>/api/notificacoes.
Adicione o cabe�alho Authorization com o valor Bearer <token>.

Atualizar Notifica��o:
Fa�a uma requisi��o PUT para https://localhost:<port>/api/notificacoes/{id}.
Adicione o cabe�alho Authorization com o valor Bearer <token>.

No corpo da requisi��o, adicione os dados atualizados da notifica��o.
{
  "titulo": "Notifica��o de Teste",
  "mensagem": "Esta � uma mensagem de teste",
  "dataEnvio": "2024-06-27T00:08:32.883Z",
  "enviada": true
}

Excluir Notifica��o:
Fa�a uma requisi��o DELETE para https://localhost:<port>/api/notificacoes/{id}.
Adicione o cabe�alho Authorization com o valor Bearer <token>.

Com essas etapas, voc� deve conseguir testar todos os endpoints e garantir que sua aplica��o est� funcionando corretamente.

