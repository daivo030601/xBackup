<template>
  <div class="wrapper-home-page">
    <nav class="border-gray-200 bg-gray-100 px-2 sm:px-4 py-2.5 rounded">
      <div
        class="container flex flex-wrap items-center justify-between mx-auto"
      >
        <img
          src="https://arc-qa.bigin.top/assets/login-media/logo.png"
          class="mb-3"
        />
        <button
          data-collapse-toggle="navbar-default"
          type="button"
          class="inline-flex items-center p-2 ml-3 text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200"
          aria-controls="navbar-default"
          aria-expanded="false"
        >
          <span class="sr-only">Open main menu</span>
          <svg
            class="w-6 h-6"
            aria-hidden="true"
            fill="currentColor"
            viewBox="0 0 20 20"
            xmlns="http://www.w3.org/2000/svg"
          >
            <path
              fill-rule="evenodd"
              d="M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 15a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1z"
              clip-rule="evenodd"
            ></path>
          </svg>
        </button>
        <div class="hidden w-full md:block md:w-auto" id="navbar-default">
          <ul
            class="items-center flex flex-col p-4 mt-4 border border-gray-100 rounded-lg bg-gray-100 md:flex-row md:space-x-8 md:mt-0 md:text-sm md:font-medium md:border-0 md:bg-gray-100"
          >
            <li>
              <a
                href="#"
                class="block py-2 pl-3 pr-4 text-white bg-blue-700 rounded md:bg-transparent md:text-blue-700 md:p-0"
                aria-current="page"
                >Home</a
              >
            </li>
            <li>
              <a
                href="#"
                class="block py-2 pl-3 pr-4 text-gray-700 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0"
                >About</a
              >
            </li>
            <li>
              <a
                href="#"
                class="block py-2 pl-3 pr-4 text-gray-700 rounded hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0"
                >Services</a
              >
            </li>
            <li>
              <nuxt-link to="/login">Login</nuxt-link>
            </li>
            <li>
              <button
                type="button"
                class="focus:outline-none text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 mr-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900"
              >
                <nuxt-link to="/register">Get started</nuxt-link>
              </button>
            </li>
          </ul>
        </div>
      </div>
    </nav>
    <div class="page-contents">
      <div class="section-1 relative">
        <div class="container relative mr-30 ml-auto grid grid-cols-2 p-20">
          <div class="section-1-1 grid grid-rows-3 pr-20">
            <div class="text-6xl font-bold">Backups just got easy.</div>
            <div class="text-xl font-semibold pt-3">
              Automate your in 2 minutes. Sleep easy knowing your critical
              information is safe. You deserve it.
            </div>
            <div class="pt-3">
              <button
                type="button"
                class="focus:outline-none text-white text-xl p-5 bg-red-700 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm mr-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900"
              >
                <nuxt-link to="/register"
                  >Get your first backup for free. Forever.</nuxt-link
                >
              </button>
              <div class="text-sm font-normal">
                14 Day Free Trial • Cancel Anytime • No Credit Card Required
              </div>
            </div>
          </div>
          <div class="section-1-2">
            <img src="../public/img/xbackup.png" alt="" />
          </div>
        </div>
      </div>
      <div class="section-2 grid grid-rows-2">
        <div class="text-xl font-semibold mr-auto ml-auto relative px-10">
          Trusted by 2,000+ developers, agencies, and startups
        </div>
        <div class="mr-auto ml-auto relative py-5 w-full">
          <div class="logos grid grid-cols-3">
            <div class="feature-third items-center justify-center flex">
              <img
                src="https://uploads-ssl.webflow.com/62699435f0eac13a70dcc10d/62699d0871be8a769d11bcc0_laravel-news.svg"
                alt=""
              />
            </div>
            <div class="feature-third items-center justify-center flex">
              <img
                src="https://uploads-ssl.webflow.com/62699435f0eac13a70dcc10d/62699d0888fbee4a26e22f7d_laracsts.svg"
                alt=""
              />
            </div>
            <div class="feature-third items-center justify-center flex">
              <img
                src="https://uploads-ssl.webflow.com/62699435f0eac13a70dcc10d/62699d082f6172b778328215_laravel.svg"
                alt=""
              />
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup lang="ts">
  useHead({
    title: "XBackUp Project",
  });

</script>
<style scoped>
.section-1-2 {
  background-image: "../public/img/xbackup.png";
}
</style>
