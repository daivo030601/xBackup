<template>
  <div
    class="wrapper-token-expired"
    :class="{ openTokenExpired: isTokenExpired }"
  >
    <div
      class="token-expired-content relative p-4 w-full max-w-lg h-full md:h-auto"
    >
      <div class="relative p-4 bg-white rounded-lg shadow md:p-8">
        <div class="mb-4 text-sm font-light text-gray-500">
          <h3 class="mb-3 text-2xl font-bold text-gray-900">Privacy info</h3>
          <p>Your Login has been expired. Please try login again!</p>
        </div>
        <div
          class="justify-between items-center pt-0 space-y-4 sm:flex sm:space-y-0"
        >
          <a
            href="#"
            class="font-medium text-primary-600 dark:text-primary-500 hover:underline"
            >Learn more about privacy</a
          >
          <div class="items-center space-y-4 sm:space-x-4 sm:flex sm:space-y-0">
            <button
              @click="cancelExpired"
              id="close-modal"
              type="button"
              class="py-2 px-4 w-full text-sm font-medium text-gray-500 bg-white rounded-lg border border-gray-200 sm:w-auto hover:bg-gray-100 focus:ring-4 focus:outline-none focus:ring-primary-300 hover:text-gray-900 focus:z-10"
            >
              Cancel
            </button>
            <button
              @click="submitExpired"
              id="confirm-button"
              type="button"
              class="py-2 px-4 w-full text-sm font-medium text-center rounded-lg bg-primary-700 sm:w-auto hover:bg-primary-800 focus:ring-4 focus:outline-none focus:ring-primary-300"
            >
              Confirm
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup lang="ts">
const props = defineProps<{
  isTokenExpired: Boolean;
}>();

const emits = defineEmits<{
  (e: "submitExpired"): void;
  (e: "cancelExpired"): void;
}>();

function submitExpired() {
  emits("submitExpired");
}
function cancelExpired() {
  emits("cancelExpired");
}
</script>
<style scoped>
.wrapper-token-expired {
  display: flex;
  justify-content: center;
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: rgba(0, 0, 0, 0.4);
  opacity: 0;
  visibility: hidden;
  transition: all 0.3s ease;
}
.token-expired-content {
  position: absolute;
  top: 25%;
  width: 500px;
  background-color: whitesmoke;
}
.openTokenExpired {
  opacity: 1;
  visibility: visible;
}
</style>
