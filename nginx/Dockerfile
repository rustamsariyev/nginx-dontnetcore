FROM nginx:latest

COPY nginx.conf /etc/nginx/nginx.conf
COPY reverseproxy.conf /etc/nginx/reverseproxy.conf
RUN  chmod 775 /etc/nginx/reverseproxy.conf
COPY library.az.crt /etc/ssl/certs/library.az.crt
COPY library.az.key /etc/ssl/certs/library.az.key

