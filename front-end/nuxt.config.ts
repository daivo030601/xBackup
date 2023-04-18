
// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
    modules: [
        '@element-plus/nuxt',
        '@nuxtjs/tailwindcss',
    ],
    css: ['~/assets/css/main.css'],
    postcss: {
    plugins: {
      tailwindcss: {},
      autoprefixer: {},
    },
    },
    ssr: false,
    runtimeConfig:{
        public:{
          API_BASE_URL: process.env.API_BASE_URL
        }
    },
})
