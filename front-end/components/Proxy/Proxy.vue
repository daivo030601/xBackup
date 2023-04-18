<template>
  <div>
    <div class="mt-4">
      <h2 class="text-md font-medium mb-2">Connection String Scheme</h2>
      <div class="flex mb-2">
        <button class="px-8 rounded-md mr-4 py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(1)" :class="{'border-indigo-500 text-indigo-600': subActiveTab === 1}">
          None
        </button>
        <button class="px-8 rounded-md mr-4 py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(2)" :class="{'border-indigo-500 text-indigo-600': subActiveTab === 2}">
          SSH with Password
        </button>
        <button class="px-8 rounded-md mr-4 py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(3)" :class="{'border-indigo-500 text-indigo-600': subActiveTab === 3}">
          SSH with Identity File
        </button>
        <button class="px-8 rounded-md py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(4)" :class="{'border-indigo-500 text-indigo-600': subActiveTab === 4}">
          Socks5
        </button>
      </div>
      
    </div>
    <div v-if="subActiveTab === 1" class="border-none p-2">
      <!-- Content for Subtab 1 -->
      
      
    </div>
    <div v-if="subActiveTab === 2" class="border-none p-2">
      <!-- Content for Subtab 2 -->
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">SSH Hostname</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.hostName"
              type="text"
              autocomplete="off"
              placeholder="hostname..."
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">SSH Port</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.port"
              type="number"
              autocomplete="off"
              placeholder="port"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">SSH Username</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.sshUserName"
              type="text"
              autocomplete="off"
              placeholder="SSH Username"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container ">
        <label class="form-item__label">
          <span class="text-base">SSH Password</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.sshPassword"
              type="text"
              autocomplete="off"
              placeholder="SSH Password"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
    </div>
    <div v-if="subActiveTab === 3" class="border-none p-2">
      <!-- Content for Subtab 1 -->
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">SSH Hostname</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.hostName"
              type="text"
              autocomplete="off"
              placeholder="hostname..."
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">SSH Port</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.port"
              type="number"
              autocomplete="off"
              placeholder="port"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">SSH Username</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.sshUserName"
              type="text"
              autocomplete="off"
              placeholder="SSH Username"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <form class="input-container mb-4">
        <div>
          <label for="file" class="mr-8 form-item__label"><span class="text-base">SSH Identity File</span></label>
          <input type="file" id="file" name="file">
        </div>
      </form>
      <div class="input-container">
        <label class="form-item__label">
          <span class="text-base">SSH Password</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.sshPassword"
              type="text"
              autocomplete="off"
              placeholder="SSH Password"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      
    </div>
    <div v-if="subActiveTab === 4" class="border-none p-2">
      <!-- Content for Subtab 1 -->
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">Proxy Hostname</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.hostName"
              type="text"
              autocomplete="off"
              placeholder=""
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">Proxy Tunnel Port</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.port"
              type="number"
              autocomplete="off"
              placeholder="port"
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container mb-4">
        <label class="form-item__label">
          <span class="text-base">Proxy Username</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.sshUserName"
              type="text"
              autocomplete="off"
              placeholder=""
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
      <div class="input-container">
        <label class="form-item__label">
          <span class="text-base">Proxy Password</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              v-model="proxy.sshPassword"
              type="text"
              autocomplete="off"
              placeholder=""
              class="b-input__inner"
              fdprocessedid="ulryzn"
            />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue';
  import { defineProps, PropType, defineEmits } from 'vue'
  const subActiveTab = ref(1);
  const emits = defineEmits(['update:method','update:noneMethod'])

  const props = defineProps({
    proxy: {
      type: Object as PropType<{ 
        isWithPass: boolean,
        isWithIdentityFile: boolean,
        isSocks5: boolean,
        hostName: string,
        port: number,
        sshUserName: string,
        sshPassword: string,
      }>,
      required: true
    }
  }) 

  function setSubActiveTab(tabNumber: number) {
    if (tabNumber == 1) {
      emits('update:noneMethod', {
          isUsed : false,
          isWithPass: false,
          isWithIdentityFile: false,
          isSocks5: false,
          hostName: '',
          port: 0,
          sshUsername: '',
          sshPassword: '',
        })
      
    } else if (tabNumber == 2) {
      emits('update:method', {
          isUsed : true,
          isWithPass: true,
          isWithIdentityFile: false,
          isSocks5: false,
        })
    } else if (tabNumber == 3) {
      emits('update:method', {
          isUsed : true,
          isWithPass: false,
          isWithIdentityFile: true,
          isSocks5: false,
        })
      }else {
      emits('update:method', {
          isUsed : true,
          isWithPass: false,
          isWithIdentityFile: false,
          isSocks5: true,
        })
    }
    subActiveTab.value = tabNumber;
  }

  
</script>

<style lang="scss" scoped>
@import "./_proxy.scss";
</style>