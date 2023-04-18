<template>
  <div
    v-if="isSuccessed"
    id="alert-3"
    class="flex p-4 mb-4 text-green-800 rounded-lg bg-green-50"
    role="alert"
  >
    <svg
      aria-hidden="true"
      class="flex-shrink-0 w-5 h-5"
      fill="currentColor"
      viewBox="0 0 20 20"
      xmlns="http://www.w3.org/2000/svg"
    >
      <path
        fill-rule="evenodd"
        d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z"
        clip-rule="evenodd"
      ></path>
    </svg>
    <span class="sr-only">Info</span>
    <div class="ml-3 text-sm font-medium">Change password succeed!</div>
    <button
      @click="handleCloseAlert"
      type="button"
      class="ml-auto -mx-1.5 -my-1.5 bg-green-50 text-green-500 rounded-lg focus:ring-2 focus:ring-green-400 p-1.5 hover:bg-green-200 inline-flex h-8 w-8"
      data-dismiss-target="#alert-3"
      aria-label="Close"
    >
      <span class="sr-only">Close</span>
      <svg
        aria-hidden="true"
        class="w-5 h-5"
        fill="currentColor"
        viewBox="0 0 20 20"
        xmlns="http://www.w3.org/2000/svg"
      >
        <path
          fill-rule="evenodd"
          d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
          clip-rule="evenodd"
        ></path>
      </svg>
    </button>
  </div>
  <div
    class="wrapper-reset-password"
    :class="{ openResetPassword: isOpenResetPassword }"
    v-loading="loading"
    element-loading-background="rgba(122, 122, 122, 0.8)"
  >
    <div
      class="reset-password-content w-full p-6 bg-white rounded-lg shadow dark:border md:mt-0 sm:max-w-md"
    >
      <h2
        class="mb-1 text-xl font-bold leading-tight tracking-tight text-gray-900 md:text-2xl"
      >
        Change Password
      </h2>
      <div class="text-red-600 font-bold text-xl">
        {{ error }}
      </div>
      <form class="mt-4 space-y-4 lg:mt-5 md:space-y-5">
        <div>
          <label
            for="old-password"
            class="block mb-2 text-sm font-medium text-gray-900"
            >Old password</label
          >
          <input
            v-model="changePasswordForm.oldPassword"
            type="password"
            name="old-password"
            id="old-password"
            class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
            placeholder="••••••••"
          />
        </div>
        <div>
          <label
            for="password"
            class="block mb-2 text-sm font-medium text-gray-900"
            >New Password</label
          >
          <input
            v-model="changePasswordForm.newPassword"
            type="password"
            name="password"
            id="password"
            placeholder="••••••••"
            :class="v$.newPassword.$error ? 'border-rose-500' : ''"
            class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
          />
          <div v-if="v$.newPassword.$error" class="text-red-600">
            Password is invalid, must be at least 6 characters
          </div>
        </div>
        <div>
          <label
            for="confirm-password"
            class="block mb-2 text-sm font-medium text-gray-900"
            >Confirm password</label
          >
          <input
            v-model="changePasswordForm.confirmNewPassword"
            type="password"
            name="confirm-password"
            id="confirm-password"
            placeholder="••••••••"
            :class="v$.confirmNewPassword.$error ? 'border-rose-500' : ''"
            class="bg-gray-50 border border-gray-300 text-gray-900 sm:text-sm rounded-lg focus:ring-primary-600 focus:border-primary-600 block w-full p-2.5"
          />
          <div v-if="v$.confirmNewPassword.$error" class="text-red-600">
            Must be the same as the password
          </div>
        </div>
        <div class="flex items-start">
          <div class="flex items-center h-5">
            <input
              id="newsletter"
              aria-describedby="newsletter"
              type="checkbox"
              class="w-4 h-4 border border-gray-300 rounded bg-gray-50 focus:ring-3 focus:ring-primary-300"
            />
          </div>
          <div class="ml-3 text-sm">
            <label for="newsletter" class="font-light text-gray-500"
              >I accept the
              <a class="font-medium text-primary-600 hover:underline" href="#"
                >Terms and Conditions</a
              ></label
            >
          </div>
        </div>
        <button
          @click.prevent="handleChangePassword"
          type="submit"
          class="w-full bg-primary-600 hover:bg-primary-700 focus:ring-4 focus:outline-none focus:ring-primary-300 font-medium rounded-lg text-sm px-5 py-2.5 text-center"
        >
          Reset passwod
        </button>
      </form>
    </div>
  </div>
</template>
<script setup lang="ts">
import useVuelidate from "@vuelidate/core";
import { minLength, required, sameAs } from "@vuelidate/validators";
import { ChangePasswordForm, ResponseModel } from "~~/model/Model";

const props = defineProps<{
  isOpenResetPassword: Boolean;
}>();

const emits = defineEmits<{
  (e: "changePasswordSuccess"): void;
}>();

const config = useRuntimeConfig();
const API_BASE_URL = config.public.API_BASE_URL;

const changePasswordForm = ref<ChangePasswordForm>({
  email: "",
  oldPassword: "",
  newPassword: "",
  confirmNewPassword: "",
});
const isSuccessed = ref<Boolean>(false);
const error = ref<string>("");
const loading = ref<Boolean>(false);

//=== Valiate the register================================

const rules = computed(() => ({
  oldPassword: {
    required,
  },
  newPassword: {
    minLength: minLength(6),
    required,
  },
  confirmNewPassword: {
    required,
    sameAsPassword: sameAs(changePasswordForm.value.newPassword),
  },
}));
const v$ = useVuelidate(rules, changePasswordForm.value);
//================================================================
async function handleChangePassword() {
  v$.value.$touch();
  loading.value = true;
  console.log(JSON.stringify(changePasswordForm.value));
  console.log(
    "validate new password",
    v$.value.newPassword.$error,
    "validate confirmation new password",
    v$.value.confirmNewPassword.$error
  );
  if (v$.value.$error) {
    return;
  }
  changePasswordForm.value.email = state.userEmail as string;
  const { data, ...restData } = await useFetch(
    `${API_BASE_URL}/User/change-password`,
    {
      method: "POST",
      headers: {
        "content-type": "application/json",
      },
      body: JSON.stringify(changePasswordForm.value),
    }
  );
  if (data != null) {
    loading.value = false;
  }
  const dataObject = JSON.parse(JSON.stringify(data.value)) as ResponseModel;
  if (dataObject != null) {
    emits("changePasswordSuccess");
    isSuccessed.value = true;
  } else {
    error.value = "Old password is wrong";
  }
}
function handleCloseAlert() {
  isSuccessed.value = false;
}
</script>
<style scoped>
.wrapper-reset-password {
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
.reset-password-content {
  position: absolute;
  top: 20%;
  width: 500px;
  background-color: whitesmoke;
}
.openResetPassword {
  opacity: 1;
  visibility: visible;
}
</style>
