<template>
  <div>
    <section class="bg-gray-50 dark:bg-gray-900">
      <div
        class="flex flex-col items-center justify-center px-6 py-8 mx-auto md:h-screen lg:py-0"
      >
        <img
          src="https://arc-qa.bigin.top/assets/login-media/logo.png"
          class="mb-3"
        />
        <div
          class="w-full bg-white rounded-lg shadow dark:border md:mt-0 sm:max-w-md xl:p-0"
        >
          <div class="p-6 space-y-4 md:space-y-6 sm:p-8">
            <h1
              class="text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl"
            >
              Create and account
            </h1>
            <form
              class="space-y-4 md:space-y-6"
              @submit.prevent="submitRegister"
            >
              <div>
                <label
                  for="first-name"
                  class="block mb-2 text-sm font-medium text-gray-900"
                  >First Name</label
                >
                <input
                  v-model="registerForm.firstName"
                  type="text"
                  name="first-name"
                  id="first-name"
                  class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                  placeholder="Nguyen"
                  :class="v$.firstName.$error ? 'border-rose-500' : ''"
                />
                <div v-if="v$.firstName.$error" class="text-red-500 m-3">
                  First name is required
                </div>
              </div>
              <div>
                <label
                  for="last-name"
                  class="block mb-2 text-sm font-medium text-gray-900"
                  >Last Name</label
                >
                <input
                  v-model="registerForm.lastName"
                  type="text"
                  name="last-name"
                  id="last-name"
                  class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                  placeholder="Van A"
                  :class="v$.lastName.$error ? 'border-rose-500' : ''"
                />
                <div v-if="v$.lastName.$error" class="text-red-500 m-3">
                  Last name is required
                </div>
              </div>
              <div>
                <label
                  for="email"
                  class="block mb-2 text-sm font-medium text-gray-900"
                  >Your email</label
                >
                <input
                  v-model="registerForm.email"
                  type="text"
                  name="email"
                  id="email"
                  class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                  placeholder="name@company.com"
                  :class="v$.email.$error ? 'border-rose-500' : ''"
                />
                <div v-if="v$.email.$error" class="text-red-500 m-3">
                  Email is not a valid
                </div>
              </div>
              <div>
                <label
                  for="password"
                  class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >Password</label
                >
                <input
                  v-model="registerForm.password"
                  type="password"
                  name="password"
                  id="password"
                  placeholder="Must contain at least one character"
                  :class="v$.password.$error ? 'border-rose-500' : ''"
                  class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                />
                <div v-if="v$.password.$error" class="text-red-500 m-3">
                  Password is invalid, must be at least 6 characters
                </div>
              </div>
              <div>
                <label
                  for="confirm-password"
                  class="block mb-2 text-sm font-medium text-gray-900 dark:text-white"
                  >Confirm password</label
                >
                <input
                  v-model="registerForm.confirmPassword"
                  type="password"
                  name="confirm-password"
                  id="confirm-password"
                  placeholder="••••••••"
                  :class="v$.confirmPassword.$error ? 'border-rose-500' : ''"
                  class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
                />
                <div v-if="v$.confirmPassword.$error" class="text-red-500 m-3">
                  Must be the same as the password
                </div>
              </div>
              <div class="flex items-start">
                <div class="flex items-center h-5">
                  <input
                    id="terms"
                    aria-describedby="terms"
                    type="checkbox"
                    class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300"
                  />
                </div>
                <div class="ml-3 text-sm">
                  <label for="terms" class="font-light text-gray-500"
                    >I accept the
                    <a
                      class="font-medium text-primary-600 hover:underline"
                      href="#"
                      >Terms and Conditions</a
                    ></label
                  >
                </div>
              </div>
              <button
                type="submit"
                class="w-full bg-primary-600 hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
              >
                Create an account
              </button>
              <p class="text-sm font-light text-gray-500">
                Already have an account?
                <nuxt-link
                  to="/"
                  class="font-medium text-primary-600 hover:underline dark:text-primary-500"
                  >Login here</nuxt-link
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
import { RegisterForm, ResponseModel } from "../model/Model";
import { required, email, minLength, sameAs } from "@vuelidate/validators";
import useVuelidate from "@vuelidate/core";
useHead({
  title: "Register",
});
const config = useRuntimeConfig();
const API_BASE_URL = config.public.API_BASE_URL;

const registerForm = ref<RegisterForm>({
  email: "",
  password: "",
  firstName: "",
  lastName: "",
  confirmPassword: "",
});
const RePassword = ref<string>("");
//=== Valiate the register================================

const rules = computed(() => ({
  email: {
    required,
    email,
  },
  password: {
    minLength: minLength(6),
    required,
  },
  firstName: {
    required,
  },
  lastName: {
    required,
  },
  confirmPassword: {
    required,
    sameAsPassword: sameAs(registerForm.value.password),
  },
}));
const v$ = useVuelidate(rules, registerForm.value);
//================================================================

async function submitRegister() {
  v$.value.$touch();
  console.log(JSON.stringify(registerForm.value));
  console.log("validate", v$.value.email.$error);
  if (v$.value.$error) {
    return;
  }
  const { data, ...restData } = await useFetch(`${API_BASE_URL}User/register`, {
    method: "POST",
    headers: {
      "content-type": "application/json",
    },
    body: JSON.stringify(registerForm.value),
  });
  const dataObject = JSON.parse(JSON.stringify(data.value)) as ResponseModel;
  if (dataObject != null) {
    navigateTo("/");
  }
}
</script>
<style></style>
