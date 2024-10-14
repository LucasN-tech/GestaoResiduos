O projeto foi feito utilizando um banco de dados em memory para ser funcional criamos 4 endpoint para envio de notificações de coleta de lixo. 




Testando com Postman

Este guia explica como testar os endpoints da API utilizando o Postman. Certifique-se de substituir <port> pela porta configurada na sua aplicação.

Gerar o Token JWT
Faça uma requisição POST para https://localhost:<port>/api/auth/login.
Copie o token JWT da resposta.

Enviar Notificação:
Faça uma requisição POST para https://localhost:<port>/api/notificacoes.
Adicione o cabeçalho Authorization com o valor Bearer <token>.

No corpo da requisição, adicione os dados da notificação no formato JSON:
{
  "titulo": "Notificação de Teste",
  "mensagem": "Esta é uma mensagem de teste",
  "dataEnvio": "2024-06-27T00:08:32.883Z",
  "enviada": true
}

Obter Notificações:
Faça uma requisição GET para https://localhost:<port>/api/notificacoes.
Adicione o cabeçalho Authorization com o valor Bearer <token>.

Atualizar Notificação:
Faça uma requisição PUT para https://localhost:<port>/api/notificacoes/{id}.
Adicione o cabeçalho Authorization com o valor Bearer <token>.

No corpo da requisição, adicione os dados atualizados da notificação.
{
  "titulo": "Notificação de Teste",
  "mensagem": "Esta é uma mensagem de teste",
  "dataEnvio": "2024-06-27T00:08:32.883Z",
  "enviada": true
}

Excluir Notificação:
Faça uma requisição DELETE para https://localhost:<port>/api/notificacoes/{id}.
Adicione o cabeçalho Authorization com o valor Bearer <token>.

Com essas etapas, você deve conseguir testar todos os endpoints e garantir que sua aplicação está funcionando corretamente.

