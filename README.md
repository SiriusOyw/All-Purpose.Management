# All-Purpose.Management

<template>
  <div class="transfer-container">
    <div class="transfer-panel">
      <div class="panel-header">源数据</div>
      <div class="panel-body">
        <div class="table-container">
          <el-table
            ref="leftTable"
            :data="leftFilteredData"
            border
            style="width: 100%"
            @selection-change="handleLeftSelectionChange"
          >
            <el-table-column type="selection" width="55" />
            <el-table-column prop="id" label="ID" width="80" />
            <el-table-column prop="name" label="姓名" />
            <el-table-column prop="age" label="年龄" width="80" />
            <el-table-column prop="address" label="地址" />
            <el-table-column prop="email" label="邮箱" />
          </el-table>
        </div>
        <div class="pagination">
          <el-pagination
            v-model:current-page="leftCurrentPage"
            v-model:page-size="leftPageSize"
            :page-sizes="[5, 10, 20, 50]"
            :total="leftTotal"
            layout="total, sizes, prev, pager, next, jumper"
            @size-change="handleLeftSizeChange"
            @current-change="handleLeftCurrentChange"
          />
        </div>
      </div>
    </div>

    <div class="transfer-buttons">
      <button
        class="transfer-button"
        :disabled="leftSelected.length === 0"
        @click="moveToRight"
      >
        <i class="el-icon-arrow-right">To Left</i>
      </button>
      <button
        class="transfer-button"
        :disabled="rightSelected.length === 0"
        @click="moveToLeft"
      >
        <i class="el-icon-arrow-left">To Right</i>
      </button>
    </div>

    <div class="transfer-panel">
      <div class="panel-header">目标数据</div>
      <div class="panel-body">
        <div class="table-container">
          <el-table
            ref="rightTable"
            :data="rightFilteredData"
            border
            style="width: 100%"
            @selection-change="handleRightSelectionChange"
          >
            <el-table-column type="selection" width="55" />
            <el-table-column prop="id" label="ID" width="80" />
            <el-table-column prop="name" label="姓名" />
            <el-table-column prop="age" label="年龄" width="80" />
            <el-table-column prop="address" label="地址" />
            <el-table-column prop="email" label="邮箱" />
          </el-table>
        </div>
        <div class="pagination">
          <el-pagination
            v-model:current-page="rightCurrentPage"
            v-model:page-size="rightPageSize"
            :page-sizes="[5, 10, 20, 50]"
            :total="rightTotal"
            layout="total, sizes, prev, pager, next, jumper"
            @size-change="handleRightSizeChange"
            @current-change="handleRightCurrentChange"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from "vue";
import { ElInput, ElTable, ElTableColumn, ElPagination } from "element-plus";

// 左侧数据
const leftData = ref([
  {
    id: 1,
    name: "张三",
    age: 25,
    address: "北京市朝阳区",
    email: "zhangsan@example.com"
  },
  {
    id: 2,
    name: "李四",
    age: 30,
    address: "上海市浦东新区",
    email: "lisi@example.com"
  },
  {
    id: 3,
    name: "王五",
    age: 28,
    address: "广州市天河区",
    email: "wangwu@example.com"
  },
  {
    id: 4,
    name: "赵六",
    age: 35,
    address: "深圳市南山区",
    email: "zhaoliu@example.com"
  },
  {
    id: 5,
    name: "钱七",
    age: 22,
    address: "成都市武侯区",
    email: "qianqi@example.com"
  },
  {
    id: 6,
    name: "孙八",
    age: 27,
    address: "杭州市西湖区",
    email: "sunba@example.com"
  },
  {
    id: 7,
    name: "周九",
    age: 32,
    address: "武汉市洪山区",
    email: "zhoujiu@example.com"
  },
  {
    id: 8,
    name: "吴十",
    age: 29,
    address: "南京市鼓楼区",
    email: "wushi@example.com"
  },
  {
    id: 9,
    name: "郑十一",
    age: 31,
    address: "西安市雁塔区",
    email: "zhengshiyi@example.com"
  },
  {
    id: 10,
    name: "王十二",
    age: 26,
    address: "重庆市渝中区",
    email: "wangshier@example.com"
  }
]);

// 右侧数据
const rightData = ref([]);

// 左侧选择项
const leftSelected = ref([]);

// 右侧选择项
const rightSelected = ref([]);

// 左侧搜索
const leftSearch = ref("");

// 右侧搜索
const rightSearch = ref("");

// 左侧分页
const leftCurrentPage = ref(1);
const leftPageSize = ref(5);
const leftTotal = computed(() => leftData.value.length);

// 右侧分页
const rightCurrentPage = ref(1);
const rightPageSize = ref(5);
const rightTotal = computed(() => rightData.value.length);

// 左侧过滤后的数据
const leftFilteredData = computed(() => {
  let filtered = leftData.value;

  // 搜索过滤
  if (leftSearch.value) {
    const search = leftSearch.value.toLowerCase();
    filtered = filtered.filter(
      item =>
        item.name.toLowerCase().includes(search) ||
        item.address.toLowerCase().includes(search) ||
        item.email.toLowerCase().includes(search)
    );
  }

  // 分页
  const start = (leftCurrentPage.value - 1) * leftPageSize.value;
  const end = start + leftPageSize.value;
  return filtered.slice(start, end);
});

// 右侧过滤后的数据
const rightFilteredData = computed(() => {
  let filtered = rightData.value;

  // 搜索过滤
  if (rightSearch.value) {
    const search = rightSearch.value.toLowerCase();
    filtered = filtered.filter(
      item =>
        item.name.toLowerCase().includes(search) ||
        item.address.toLowerCase().includes(search) ||
        item.email.toLowerCase().includes(search)
    );
  }

  // 分页
  const start = (rightCurrentPage.value - 1) * rightPageSize.value;
  const end = start + rightPageSize.value;
  return filtered.slice(start, end);
});

// 左侧选择变化
const handleLeftSelectionChange = val => {
  leftSelected.value = val;
};

// 右侧选择变化
const handleRightSelectionChange = val => {
  rightSelected.value = val;
};

// 移动到右侧
const moveToRight = () => {
  leftSelected.value.forEach(item => {
    const index = leftData.value.findIndex(i => i.id === item.id);
    if (index !== -1) {
      rightData.value.push(leftData.value[index]);
      leftData.value.splice(index, 1);
    }
  });
  leftSelected.value = [];
};

// 移动到左侧
const moveToLeft = () => {
  rightSelected.value.forEach(item => {
    const index = rightData.value.findIndex(i => i.id === item.id);
    if (index !== -1) {
      leftData.value.push(rightData.value[index]);
      rightData.value.splice(index, 1);
    }
  });
  rightSelected.value = [];
};

// 左侧搜索清除
const handleLeftSearchClear = () => {
  leftSearch.value = "";
  leftCurrentPage.value = 1;
};

// 右侧搜索清除
const handleRightSearchClear = () => {
  rightSearch.value = "";
  rightCurrentPage.value = 1;
};

// 左侧搜索
const handleLeftSearch = () => {
  leftCurrentPage.value = 1;
};

// 右侧搜索
const handleRightSearch = () => {
  rightCurrentPage.value = 1;
};

// 左侧分页大小变化
const handleLeftSizeChange = val => {
  leftPageSize.value = val;
};

// 左侧当前页变化
const handleLeftCurrentChange = val => {
  leftCurrentPage.value = val;
};

// 右侧分页大小变化
const handleRightSizeChange = val => {
  rightPageSize.value = val;
};

// 右侧当前页变化
const handleRightCurrentChange = val => {
  rightCurrentPage.value = val;
};

// (已移除 export default，<script setup> 不需要导出对象)
</script>

<style>
.transfer-container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
  padding: 20px;
  background-color: #f5f7fa;
  border-radius: 8px;
  box-shadow: 0 2px 12px 0 rgba(0, 0, 0, 0.1);
}

.transfer-panel {
  flex: 1;
  border: 1px solid #ebeef5;
  border-radius: 4px;
  background-color: #fff;
  overflow: hidden;
}

.transfer-buttons {
  display: flex;
  flex-direction: column;
  margin: 0 20px;
}

.transfer-button {
  margin: 10px 0;
  padding: 10px 15px;
  border-radius: 4px;
  background-color: #409eff;
  color: white;
  border: none;
  cursor: pointer;
  transition: all 0.3s;
}

.transfer-button:hover {
  background-color: #66b1ff;
}

.transfer-button:disabled {
  background-color: #a0cfff;
  cursor: not-allowed;
}

.panel-header {
  padding: 15px;
  border-bottom: 1px solid #ebeef5;
  background-color: #f5f7fa;
  font-weight: bold;
}

.panel-body {
  padding: 15px;
}

.search-input {
  margin-bottom: 15px;
  width: 100%;
}

.pagination {
  margin-top: 15px;
  display: flex;
  justify-content: flex-end;
}

.table-container {
  height: 400px;
  overflow-y: auto;
}
</style>
