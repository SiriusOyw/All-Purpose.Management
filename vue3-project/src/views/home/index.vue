<template>
  <div id="module">
    <el-container>
        <NavMenu />
      <el-container>
        <el-header>
          <!-- 面包屑 -->
          <Breadcrumb />
          <!-- 退出按钮 -->
          <el-button class="exit" type="primary" @click="goBack()">退出</el-button>
        </el-header>
        <el-main><router-view /></el-main>
      </el-container>
    </el-container>
  </div>
</template>



<script setup>
import NavMenu from './navMenu.vue'
import Breadcrumb from './breadcrumb.vue' //引入组件
import { useRouter } from "vue-router";  //导入路由

const router = useRouter();  //实例化路由 
//退出
function goBack() {
    router.push('/login');
}
</script>

<style scoped>

</style>