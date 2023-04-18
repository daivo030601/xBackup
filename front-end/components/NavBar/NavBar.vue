<template>
  <nav class="flex items-center justify-between flex-wrap bg-blue-500 p-4">
    <div class="flex items-center flex-shrink-0 text-white mr-10">
      <router-link to="/" class="font-semibold text-xl tracking-tight">XBackUp</router-link>
    </div>
    <div class="block lg:hidden">
      <button @click="toggle" class="flex items-center px-3 py-2 border rounded text-white border-white hover:text-gray-200 hover:border-gray-200">
        <svg class="fill-current h-3 w-3" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg">
          <title>Menu</title>
          <path d="M0 3a3 3 0 0 1 3-3h14a3 3 0 0 1 0 6H3a3 3 0 0 1-3-3zm0 7a3 3 0 0 1 3-3h14a3 3 0 0 1 0 6H3a3 3 0 0 1-3-3zm0 7a3 3 0 0 1 3-3h14a3 3 0 0 1 0 6H3a3 3 0 0 1-3-3z"/>
        </svg>
      </button>
    </div>
    <div class="w-full flex-grow lg:flex lg:items-center lg:w-auto" :class="{'block': isOpen, 'hidden': !isOpen}">
      <div class="text-lg lg:flex-grow">
        <router-link to="/" class="block mt-4 lg:inline-block lg:mt-0 text-white hover:text-gray-200 mr-4">
          Home
        </router-link>
        <router-link to="/connection" class="block mt-4 lg:inline-block lg:mt-0 text-white hover:text-gray-200 mr-4">
          Connection
        </router-link>
        <router-link to="/backup" class="block mt-4 lg:inline-block lg:mt-0 text-white hover:text-gray-200">
          Backup
        </router-link>
      </div>
    </div>
    <div>
        <button
          class="inline-block text-sm px-4 py-2 leading-none border rounded text-white border-white hover:border-transparent hover:text-gray-900 hover:bg-white mt-4 lg:mt-0"
        >
          Logout
        </button>
      </div>
  </nav>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink } from 'vue-router';

const isOpen = ref(false);

const toggle = () => {
  isOpen.value = !isOpen.value;
};
</script>
