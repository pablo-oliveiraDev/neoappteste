# Api Neo Teste

>>> Projeto feito para teste de nivelamento com intuito de gerar uma api em c# 

# Primeiros Passos⚙️


>>> Instalar o docker para ter uma comodidade maior para levantar o banco de dados passo a passo para instalar o docker nesse link [Clique aqui](https://docs.docker.com/desktop/).

>>> Após a instalação do docker veja se ele esta ativo/rodando na sua maquina se estiver ok em seguida abra o terminal navegue até o diretorio onde esta localizado a raiz do projeto e execute ```docker-compose up -d``` e ele subira e irá montar o banco de dados em seguida use o comando ```dotnet ef migrations add initialcreation``` e confirma com o comando ```dotnet ef database update``` ...
# Decisões
### Modelo padrão de MVC 📂




>>> ___Usei o modelo padrão de mvc com as pastas interface, Model, controllers,Repository e cada arquivo com a sua responsabilidade ficando prático para manutenção do codigo e nas partes que ficaram mais extensas separei com comentarios no código___


# Login

>>> Fiz o login com retorno de um token JWT que também irá retornar qual tipo de usuario que esta logado se e médico ou paciente!

# Agradecimentos 💯
>>> Agradeço a todos os envolvidos em cada parte do processo!
