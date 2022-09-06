# Locadora de Filmes Web
 
## Requisitos recomendados:
- Windows 10 ou superior;
- MySql instalado;
- Docker desktop (para plataformas Windows);
- Visual Studio Code;

## Execução do projeto:

### Criação container (Docker):
- 1 . De CD na pasta raiz do projeto pelo CMD.
- 2. Baixe a imagem do mysql usando o comando: 
> docker pull mysql

- 3. Crie o container usando o comando:
> docker run -e MYSQL_ROOT_PASSWORD=spypreto --name locadora-filmes -d -p 3366:3306 mysql

- 2. Crie a estrutura básica do banco executando o arquivo script.sql:
> docker exec -i locadora-filmes mysql -u root --password=spypreto < api/Locadora_filmes_web/Locadora_filmes_web.Data/Db/script.sql

## Referências:
### DOCKER:
- Como instalar o Docker: https://docs.docker.com/desktop/install/windows-install/
- https://docs.microsoft.com/pt-br/dotnet/architecture/containerized-lifecycle/design-develop-containerized-apps/monolithic-applications
- https://docs.microsoft.com/pt-br/windows/wsl/setup/environment#set-up-your-linux-username-and-password
- Visual Studio + SqlServer + Docker: https://www.youtube.com/watch?v=AtzE4qYgXPQ
- Connecting to MySQL on a Docker container: https://cyberomin.github.io/tutorial/docker/2016/01/12/docker-mysql.html
- Can't connect to mysql container from MySQL Workbench (Windows 10): https://github.com/docker-library/mysql/issues/274
- How to connect mysql workbench to running mysql inside docker?: https://stackoverflow.com/questions/33827342/how-to-connect-mysql-workbench-to-running-mysql-inside-docker
- Docker-Compose: Only one usage of each socket address (protocol/network address/port) is normally permitted: https://stackoverflow.com/questions/64307077/docker-compose-only-one-usage-of-each-socket-address-protocol-network-address
- Utilizando MySQL com Docker: https://www.youtube.com/watch?v=1Zpr1vX0wqk
- https://stackoverflow.com/questions/64307077/docker-compose-only-one-usage-of-each-socket-address-protocol-network-address
- https://stackoverflow.com/questions/2148746/the-operator-is-reserved-for-future-use
	
### React:
- https://ant.design/docs/react/getting-started

Problemas:
--> Failed to parse source map: 'webpack://antd/./components/time-picker/style/index.less' URL is not supported
	-> import 'antd/dist/antd.min.css
--> No 'Access-Control-Allow-Origin' header is present on the requested resource. (CORS): https://enable-cors.org/server_aspnet.html
-> https://cursos.alura.com.br/forum/topico-consumo-de-api-rest-com-javascript-78468
-> https://stackoverflow.com/questions/45975135/access-control-origin-header-error-using-axios
REFERENCIAS: 
https://stackoverflow.com/questions/71079070/react-js-updating-state-with-antd-datepicker-value
https://ant.design/components
https://codesandbox.io/s/stupefied-lehmann-byf96?file=/src/App.tsx
https://stackoverflow.com/questions/63648619/antd-how-to-get-the-entire-row-value-in-a-specific-cell-click
https://stackoverflow.com/questions/63503113/defaultvalue-of-showtime-attribute-in-antd-datepicker-couldnt-set-the-time

Passos front:
	cd na pasta web do projeto:
	npm i
	
	
### READ.ME:
- https://raullesteves.medium.com/github-como-fazer-um-readme-md-bonit%C3%A3o-c85c8f154f8
