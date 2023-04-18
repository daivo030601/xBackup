<template>
  <div v-if="isLoading" class="fixed z-50 top-0 left-0 w-screen h-screen flex items-center justify-center">
    <div class="absolute inset-0 bg-gray-800 opacity-50"></div>
    <div class="relative">
      <div class="bg-white p-4 rounded-lg shadow-md">
        <div class="flex items-center justify-center mb-4">
          <svg class="animate-spin -ml-1 mr-3 h-5 w-5 text-gray-600" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
            <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
            <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647zM20 12a8 8 0 01-8 8v4c6.627 0 12-5.373 12-12h-4zm-2-5.291A7.962 7.962 0 0120 12h4c0-3.042-1.135-5.824-3-7.938l-3 2.647z"></path>
          </svg>
          <span>Loading...</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { defineProps, ref } from 'vue';

const props = defineProps({
  isLoading: {
    type: Boolean,
  }
})
</script>
