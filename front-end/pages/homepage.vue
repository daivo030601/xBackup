<template>
  <div>This is the home page.</div>
  <button
    @click="handleOpenResetPassword"
    type="button"
    class="focus:outline-none text-white bg-purple-700 hover:bg-purple-800 focus:ring-4 focus:ring-purple-300 font-medium rounded-lg text-sm px-5 py-2.5 mb-2 dark:bg-purple-600 dark:hover:bg-purple-700 dark:focus:ring-purple-900"
  >
    ResetPassword
  </button>
  <button
    @click="handleLogout"
    type="button"
    class="focus:outline-none text-white bg-purple-700 hover:bg-purple-800 focus:ring-4 focus:ring-purple-300 font-medium rounded-lg text-sm px-5 py-2.5 mb-2 dark:bg-purple-600 dark:hover:bg-purple-700 dark:focus:ring-purple-900"
  >
    Logout
  </button>
  <ResetPassword
    :isOpenResetPassword="isOpenResetPassword"
    @changePasswordSuccess="handleChangePasswordSuccess"
  ></ResetPassword>
  <TokenExpired
    :isTokenExpired="isTokenExpired"
    @submit-expired="handleSubmitExpired"
    @cancel-expired="handleCancelExpired"
  ></TokenExpired>
</template>
<script setup lang="ts">
definePageMeta({
  middleware: "auth",
});
useHead({
  title: "Home",
});
//================================================
const isOpenResetPassword = ref<Boolean>(false);
const isTokenExpired = ref<Boolean>(false);

//================================================
onMounted(async () => {
  if (state.token === "") {
    isTokenExpired.value = true;
  }
});

function handleOpenResetPassword() {
  isOpenResetPassword.value = true;
}
function handleChangePasswordSuccess() {
  isOpenResetPassword.value = false;
}
function handleSubmitExpired() {
  state.isLogined = false;
  navigateTo("/");
}
function handleCancelExpired() {
  state.isLogined = false;
  isTokenExpired.value = false;
}
function handleLogout() {
  state.isLogined = false;
  state.token = "";
  navigateTo("/");
}
</script>
