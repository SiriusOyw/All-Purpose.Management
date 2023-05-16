<template>
   <div>
      <router-view />
   </div>
</template>

<script setup>
import {ref,reactive} from 'vue'

const obj = reactive({   //响应式数据
   title:'用户管理8888',
   count:1
})



</script>

