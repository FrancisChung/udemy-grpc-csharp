@echo off
SERVER_CN=localhost
# set OPENSSL_CONF=c:\OpenSSL-Win64\bin\openssl.cfg

echo Generate CA key:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe" genrsa -passout pass:1111 -des3 -out ca.key 4096

echo Generate CA certificate:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  req -passin pass:1111 -new -x509 -days 365 -key ca.key -out ca.crt -subj  "//CN=MyRootCA"

echo Generate server key:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  genrsa -passout pass:1111 -des3 -out server.key 4096

echo Generate server signing request:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  req -passin pass:1111 -new -key server.key -out server.csr -subj  "//CN=${SERVER_CN}"

echo Self-sign server certificate:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  x509 -req -passin pass:1111 -days 365 -in server.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out server.crt

echo Remove passphrase from server key:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  rsa -passin pass:1111 -in server.key -out server.key

echo Generate client key
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  genrsa -passout pass:1111 -des3 -out client.key 4096

echo Generate client signing request:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  req -passin pass:1111 -new -key client.key -out client.csr -subj  "//CN=${SERVER_CN}"

echo Self-sign client certificate:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  x509 -passin pass:1111 -req -days 365 -in client.csr -CA ca.crt -CAkey ca.key -set_serial 01 -out client.crt

echo Remove passphrase from client key:
"/mnt/c/Program Files/Git/usr/bin/openssl.exe"  rsa -passin pass:1111 -in client.key -out client.key

cp ca.crt ../../SSLServer/ssl/ca.crt
cp ca.crt ../../SSLClient/ssl/ca.crt

mv server.crt ../../SSLServer/ssl/server.crt
mv server.key ../../SSLServer/ssl/server.key

mv client.crt ../../SSLClient/ssl/client.crt
mv client.key ../../SSLClient/ssl/client.key