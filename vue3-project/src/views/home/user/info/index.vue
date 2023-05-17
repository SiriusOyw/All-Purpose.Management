<template>

   <el-card class="box-card">
      <!-- 当 el-table 元素中注入 data 对象数组后，在 el-table-column 中
       用 prop 属性来对应对象中的键名即可填入数据，用 label 属性来定义表格的列名。 可以使用 width 属性来定义列宽。 -->
        <el-table :data="lists" stripe style="width: 100%"  >
            <el-table-column prop="name" label="姓名" />
            <el-table-column prop="phone" label="电话" />
            <el-table-column prop="address" label="地址" />
            <el-table-column prop="QQ" label="QQ" />
            <el-table-column prop="email" label="Email" />
            <el-table-column prop="sex" label="性别">
                <template #default="{row}">
                  <el-tag  :type="row.sex==0?'':'danger'">
                    {{sexFilter(row.sex)}}
                  </el-tag>
                </template>
            </el-table-column>
        </el-table>

        <div class="pagination">
          <!-- total	总条目数
          @size-change="handleSizeChange" Size改变时会触发
          @current-change="handleCurrentChange"  页码改变时会触发-->
          <el-pagination
            background
            layout="prev, pager, next,sizes"
            :total="rows"
            :page-sizes="[10, 20, 30, 40]"
            @size-change="handleSizeChange"
            @current-change="handleCurrentChange"
          />
        </div>
        
   </el-card>
</template>

<script setup>
import {ref,reactive,onMounted,computed} from 'vue'
import axios from '@/api'

let lists = ref([]); //用户详情
let rows = ref(1);//总条数
const listQuery= reactive({
    pageindex:1, //第几页
    pageSize:10, //每页多少条
    name:''  //查询条件
});

onMounted(()=>{
  userQuery();
});

//获取用户详情  http://47.109.25.112:10089/api/User/1/10
async function userQuery(){
  let {data} = await axios.get(`/User/${listQuery.pageindex}/${listQuery.pageSize}`);
  let {data:res,success,message} = data;
  if(success) {
    lists.value = res.dataList;
    rows.value = res.recordCount; //总条数
  }else {
    console.log(message)
  }
}
//性别格式化
const sexFilter = computed(()=>item=>{
    switch(item){
        case 0:
            return '男'
         case 1:
            return '女'
        default:
            return item
    }
})

//分页 Size改变时会触发
const handleSizeChange = (val) => {
  console.log(`${val} items per page`)
  listQuery.pageSize = val;
  userQuery();
}
//页码改变时会触发
const handleCurrentChange = (val) => {
  console.log(`current page: ${val}`);
  listQuery.pageindex = val;
  userQuery();
}
</script>

