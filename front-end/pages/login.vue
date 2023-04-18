<template>
  <div
    class="wrapper-login"
    v-loading="loading"
    element-loading-background="rgba(122, 122, 122, 0.8)"
  >
    <section class="bg-gray-50 dark:bg-gray-900">
      <div
        class="flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0"
      >
        <img
          src="https://arc-qa.bigin.top/assets/login-media/logo.png"
          class="mb-3"
        />
        <div
          class="w-full bg-white rounded-lg shadow md:mt-0 sm:max-w-md xl:p-0"
        >
          <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
            <h1
              class="text-xl font-bold leading-tight tracking-tight text-red-900 md:text-2xl"
            >
              {{ error }}
            </h1>
            <form class="space-y-4 md:space-y-6" @submit.prevent="submitLogin">
              <div>
                <label
                  for="email"
                  class="block mb-2 text-sm font-medium text-gray-900"
                  >Your email</label
                >
                <input
                  v-model="loginForm.email"
                  type="text"
                  name="email"
                  id="email"
                  class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                  placeholder="name@company.com"
                  :class="v$.email.$error ? 'border-rose-500' : ''"
                />
                <div v-if="v$.email.$error" class="text-red-500 m-3">
                  Email is invalid
                </div>
              </div>
              <div>
                <label
                  for="password"
                  class="block mb-2 text-sm font-medium text-gray-900"
                  >Password</label
                >
                <input
                  v-model="loginForm.password"
                  type="password"
                  name="password"
                  id="password"
                  placeholder="••••••••"
                  :class="v$.password.$error ? 'border-rose-500' : ''"
                  class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                />
                <div v-if="v$.password.$error" class="text-red-500 m-3">
                  Password is invalid, must be at least 6 characters
                </div>
              </div>
              <div class="flex items-center justify-between">
                <div class="flex items-start">
                  <div class="flex items-center h-5">
                    <input
                      id="remember"
                      aria-describedby="remember"
                      type="checkbox"
                      class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300"
                    />
                  </div>
                  <div class="ml-3 text-sm">
                    <label for="remember" class="text-gray-500"
                      >Remember me</label
                    >
                  </div>
                </div>
                <a
                  href="#"
                  class="text-sm font-medium text-primary-600 hover:underline"
                  >Forgot password?</a
                >
              </div>
              <button
                type="submit"
                class="w-full bg-primary-600 hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
              >
                Sign in
              </button>
              <p class="text-sm font-light text-gray-500 dark:text-gray-400">
                Don’t have an account yet?
                <nuxt-link
                  to="/register"
                  class="font-medium text-primary-600 hover:underline dark:text-primary-500"
                  >Register</nuxt-link
                >
              </p>
            </form>
          </div>
        </div>
      </div>
    </section>
  </div>
</template>
<script setup lang="ts">
import { LoginForm, ResponseModel } from "~~/model/Model";
import { required, email, minLength } from "@vuelidate/validators";
import useVuelidate from "@vuelidate/core";

const config = useRuntimeConfig();
const API_BASE_URL = config.public.API_BASE_URL;

useHead({
  title: "Login",
});

const loginForm = ref<LoginForm>({
  email: "",
  password: "",
});
const loading = ref<Boolean>(false);

//=== Validate the login =================================================================

const rules = computed(() => ({
  email: {
    required,
    email,
  },
  password: {
    minLength: minLength(6),
    required,
  },
}));
const v$ = useVuelidate(rules, loginForm.value);

const error = ref<string>("");

async function submitLogin() {
  v$.value.$touch();
  loading.value = true;
  console.log(loginForm.value);
  console.log(
    "validate email:",
    v$.value.email.$error,
    "validate password:",
    v$.value.password.$error,
    "errors",
    v$.value.$error
  );
  if (v$.value.$error) {
    return;
  }
  const { data, ...restData } = await useFetch(`${API_BASE_URL}/User/login`, {
    method: "POST",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify(loginForm.value),
  });
  if (data != null) {
    loading.value = false;
  }
  const dataObject = JSON.parse(JSON.stringify(data.value)) as ResponseModel;
  if (dataObject != null) {
    // save in to the state object
    state.token = JSON.stringify(dataObject.data);
    state.isLogined = true;
    state.tokenExpired = new Date().getTime() + 60 * 60 * 1000;
    state.userEmail = loginForm.value.email;
    navigateTo("/homepage");
  } else {
    error.value = "Email or password is wrong";
  }
}
</script>
<style scoped></style>
