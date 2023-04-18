<template>
  <div>
    <div class="mt-4">
      <h2 class="text-md font-medium mb-2">Connection String Scheme</h2>
      <div class="flex mb-2">
        <button class="px-8 rounded-md mr-4 py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(1)" :class="{'border-indigo-500 text-indigo-600': subActiveTab === 1}">
          Mongodb
        </button>
        <button class="px-8 rounded-md py-2 border-2 text-gray-500 hover:text-gray-700 font-medium focus:outline-none active:border-indigo-500 active:text-indigo-600" @click="setSubActiveTab(2)" :class="{'border-indigo-500 text-indigo-600': subActiveTab === 2}">
          Mongodb+srv
        </button>
      </div>
      
    </div>
    <div v-if="subActiveTab === 1" class="border-none p-2">
      <!-- Content for Subtab 1 -->
      <h2 class="text-sm font-small mb-4">Standard Connection String Format. The standard format of the MongoDB connection URI is used to connect to a MongoDB deployment: standalone, replica set, or a sharded cluster.</h2>
      <div class="form-item rounded-2xl">
        <label class="form-item__label">
          <span class="text-base">Host</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              @input="onInput"
              v-model="general.host"
              type="text"
              autocomplete="off"
              placeholder="Give host here..."
              class="b-input__inner"
            />
          </div>
        </div>
        <div class="mt-4">
          <label class="flex items-center">
            <input type="checkbox" class="form-checkbox" v-model="general.isDirectConnection" @change="setDirectConnection">
            <span class="text-md font-medium ml-2">Direct connection</span>
          </label>
        </div>
        <h2 class="text-sm font-small mb-4">Specifies whether to force dispatch all operations to the specified host.</h2>
      </div>
      
    </div>
    <div v-if="subActiveTab === 2" class="border-none p-2">
      <!-- Content for Subtab 2 -->
      <h2 class="text-sm font-small mb-4">DNS Seed List Connection Format. The +srv indicates to the client that the hostname that follows corresponds to a DNS SRV record.</h2>
      <div class="form-item rounded-2xl">
        <label class="form-item__label">
          <span class="text-base">HostName</span>
        </label>
        <div class="b-input">
          <div class="flex-grow-1 relative">
            <input
              @input="onInput"
              v-model="general.host"
              type="text"
              autocomplete="off"
              placeholder="Give host here..."
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
  import { defineProps, PropType, defineEmits } from 'vue'

  const subActiveTab = ref(1);
  
  const props = defineProps({
    general: {
      type: Object as PropType<{ isDirectConnection: boolean, isIncludeSrv: boolean, host: string}>,
      required: true
    }
  })

  const emits = defineEmits(['update:general','update:objectGeneral','update:directConnection'])

  const onInput = (event: Event) => {
    emits('update:general', (event.target as HTMLInputElement).value)
  }

  function setSubActiveTab(tabNumber: number) {
    if (tabNumber == 2) {
      emits('update:objectGeneral', { isIncludeSrv: true, isDirectConnection: false})
      emits('update:general', 'localhost')
    }
    else {
      emits('update:objectGeneral', { isIncludeSrv: false})
      emits('update:general', 'localhost:27017')
    }
    subActiveTab.value = tabNumber;
  }

  function setDirectConnection() {
    emits('update:directConnection')
  }

</script>

<style lang="scss" scoped>
@import "./_general.scss";
</style>
