#!/bin/sh

# reconfigure nginx from env vars
sh ./templater.sh nginx.conf.default > /etc/nginx/nginx.conf

cat /etc/nginx/nginx.conf
nginx -g "daemon off;"