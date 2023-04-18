<template>
  <div class="product-list">
    <div class="grid grid-cols-1 gap-2">
      <div v-for="(server, index) in servers" :key="index" class="bg-white rounded-md shadow-md p-2 server" @click="onClickFolder(server.id)">
        <div class="font-regular text-lg mb-2">{{ server.name }}</div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
  import { defineProps, PropType, defineEmits } from 'vue'

  const emits = defineEmits(['onClickServer'])
  function onClickFolder(id: any) {
      emits('onClickServer', id);
    }
  const props = defineProps({
    servers: {
      type: Array,
      required: true
    }
  })
  
</script>

<style scoped>
.product-list {
  width: 100%;
  margin: 0 auto;
  padding: 24px;
}

.server:hover{
  background-color: #f2f2f2;
  cursor: pointer;
}
</style>
