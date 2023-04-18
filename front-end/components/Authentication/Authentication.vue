<template>
  <div>
    <div class="mt-4">
      <h2 class="text-md font-medium mb-2">Connection String Scheme</h2>
      <div class="flex mb-2">
        <button class="px-8 rounded-md mr-4 py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(1)" :class="{'border-indigo-500 text-indigo-600': tabAuth === 1}">
          None
        </button>
        <button class="px-8 rounded-md py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(2)" :class="{'border-indigo-500 text-indigo-600': tabAuth === 2}">
          Username/ Password
        </button>
      </div>
      
    </div>
    <div v-if="tabAuth === 1" class="border-none p-2">
      <!-- Content for Subtab 1 -->
      
      
    </div>
    <div v-if="tabAuth === 2" class="border-none p-2">
      <!-- Content for Subtab 2 -->
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">Username</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              @input="() => {emits('update:renderConnection')}"
              v-model="authentication.username"
              type="text"
              autocomplete="off"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">Password</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              @input="() => {emits('update:renderConnection')}"
              v-model="authentication.password"
              type="text"
              autocomplete="off"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-8">
        <label class="form-item__label">
          <span class="text-base">Authentication Database</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              @input="() => {emits('update:renderConnection')}"
              v-model="authentication.authDatabase"
              type="text"
              autocomplete="off"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>

      <div class="mt-4">
        <h2 class="text-md font-medium mb-1">Authentication Mechanism</h2>
        <div class="flex mb-2">
          <button class="px-8 rounded-md mr-4 py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setMechanismTab(1)" :class="{'border-indigo-500 text-indigo-600': mechanism === 1}">
            Default
          </button>
          <button class="px-8 rounded-md mr-4 py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setMechanismTab(2)" :class="{'border-indigo-500 text-indigo-600': mechanism === 2}">
            SCRAM-SHA-1
          </button>
          <button class="px-8 rounded-md py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setMechanismTab(3)" :class="{'border-indigo-500 text-indigo-600': mechanism === 3}">
            SCRAM-SHA-256
          </button>
        </div>
        
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import { defineProps, PropType, defineEmits } from 'vue'

  const subActiveTab = ref(1);
  const mechanism = ref(1);

  const props = defineProps({
    authentication: {
      type: Object as PropType<{ 
        isDefault: boolean,
        isSHA1: boolean,
        isSHA256: boolean,
        username: string,
        password: string,
        authDatabase: string,
      }>,
      required: true
    },
    tabAuth: {
      type: Number,
      required: true
    }
  }) 
  const emits = defineEmits(['update:usingAuth','update:objectAuthentication','update:objectMechanismAuth','update:renderConnection'])

  function setSubActiveTab(tabNumber: number) {
    if (tabNumber == 1) {
      emits('update:objectAuthentication', {
          isUsed: false,
          isDefault: false,
          isSHA1: false,
          isSHA256: false,
          username: '',
          authDatabase: '',
          password: '',
          tabAuth: tabNumber
        })
      
    } else {
      emits('update:usingAuth', {
        isUsed: true,
        isDefault: true,
        tabAuth: tabNumber
      })
    }
    
  }

  function setMechanismTab(tabNumber: number) {
    if (tabNumber == 1) {
      emits('update:objectMechanismAuth', {
          mechanism: '?authMechanism=DEFAULT',
          isDefault: true,
          isSHA1: false,
          isSHA256: false,
        })
      
    } else if (tabNumber == 2) {
      emits('update:objectMechanismAuth', {
          mechanism: '?authMechanism=SCRAM-SHA-1',
          isDefault: false,
          isSHA1: true,
          isSHA256: false,
        })
    } else {
      emits('update:objectMechanismAuth', {
          mechanism: '?authMechanism=SCRAM-SHA-256',
          isDefault: false,
          isSHA1: false,
          isSHA256: true,
        })
    }
    mechanism.value = tabNumber;
  }
</script>

<style lang="scss" scoped>
@import "./_authentication.scss";
</style>
