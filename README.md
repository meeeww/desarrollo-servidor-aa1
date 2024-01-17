# desarrollo-servidor-aa1

# Creación del contenedor
```bash
dotnet publish -c Release
```

```bash
docker build -f Dockerfile -t bankapi .
```

```bash
docker volume create datosapi  
```

```bash
docker run -d -p 6949:80 --name bankapi -v datosapi:/app/ -e STRING_CONEXION="server=212.227.32.40;database=api_clase;uid=root;password=8m!25i!17I" bankapi    
```

# Publicación del contenedor
```bash
docker login
```

```bash
docker push bankapi
```

```bash
docker tag bankapi zaaask/bankapi
```

```bash
docker push zaaask/bankapi
```

# Para ejecutar el contenedor publicado
```bash
docker pull zaaask/bankapi
```

```bash
docker run -d -p 6949:80 --name bankapi -v datosapi:/app/ -e STRING_CONEXION="server=mysqlapi;database=api_clase;uid=root;password=bbddpruebas" --network=api bankapi
```

# Creación de la base de datos
```bash
docker network create api
```

```bash
docker pull mysql
```

```bash
docker run --name mysqlapi -p 3306:3306 -e MYSQL_ROOT_PASSWORD=bbddpruebas -d mysql
```

Para crear el esquema y las tablas, referir a  BBDD.md

http://localhost:6949/swagger/index.html
