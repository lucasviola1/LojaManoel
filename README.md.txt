Com o Visual Studio aberto abra o terminal e entre na pasta sqlcustom, rode o seguinte comando:

docker-compose up -d

Volte para a pasta LojaManoel e rode os seguintes comandos:

docker build -f Dockerfile -t loja-manoel .

docker run -d -p 5000:8080 --name loja-manoel-app loja-manoel

Depois disso apenas executar uma migration abrindo o Package Manager do Visual Studio e rodar:

Add-Migration historico

Update-Database

Depois o programa ja deve funcionar normalmente(se necessário trocar o e IIS Express para Container(Dockerfile))