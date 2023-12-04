# desarrollo-servidor-aa1

docker build -f bankapi/Dockerfile -t bankapi .
docker run -d -p 6949:80 --name bankapi bankapi
