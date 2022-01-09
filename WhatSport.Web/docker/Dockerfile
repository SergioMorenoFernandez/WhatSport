FROM nginx:1.13.3-alpine


COPY entrypoint.sh entrypoint.sh
COPY templater.sh templater.sh
COPY nginx.conf.default nginx.conf.default
RUN ng build
RUN pwd
RUN chmod +x templater.sh && chmod +x entrypoint.sh
COPY dist/ /usr/share/nginx/html
ENTRYPOINT [ "./entrypoint.sh" ]
