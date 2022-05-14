FROM node:16-alpine as build-step
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:1.20.2-alpine as prod-stage
COPY --from=build-step /app/dist/imt-frontend /usr/share/nginx/html

EXPOSE 4200
CMD ["nginx", "-g", "daemon off;"]