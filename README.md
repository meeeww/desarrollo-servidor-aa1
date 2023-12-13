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
docker run -p 6949:80 --name apientornoservidor -v datosserver:/BankAPI -e STRING_CONEXION="212.227.32.40;database=api_clase;uid=root;password=8m!25i!17I" zaaask/bankapi
```

http://localhost:6949/swagger/index.html
