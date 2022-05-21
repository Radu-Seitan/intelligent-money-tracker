FROM node:16-alpine
RUN apk add --no-cache libc6-compat
WORKDIR /app
COPY package.json package-lock.json ./
RUN npm install
COPY . .

EXPOSE 4200
ENV PORT 4200
ENV NODE_ENV development
CMD ["npm", "start"]
