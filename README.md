# desarrollo-servidor-aa1

dotnet publish -c Release
docker build -f Dockerfile -t bankapi .
docker run -d -p 6949:80 --name bankapi -v datosserver:/BankAPI -e STRING_CONEXION="212.227.32.40;database=api_clase;uid=root;password=8m!25i!17I" bankapi