<template>
  <div class="breadcrumb">
    <el-breadcrumb separator="/" >
      <el-breadcrumb-item v-for="v in lists" :key="v.path">
         <router-link :to="v.path"> {{v.meta.title}}</router-link>
      </el-breadcrumb-item>
    </el-breadcrumb>
  </div>
</template>

<script setup>
import {ref,onMounted,watch} from 'vue'
import {useRouter,useRoute} from 'vue-router'

const route = useRoute(); //实例化   路由信息
const lists = ref([]); //面包屑的数据

//监听
watch(route,(newValue,oldValue)=>{
  getBreadcrumb(newValue.matched)
})
onMounted(()=>{ //挂载完成
  console.log(route);
  getBreadcrumb(route.matched)
})

function getBreadcrumb(matched){
  lists.value = matched;  //路由信息
}


</script>