<script lang="ts" setup>
import { Search as SearchIcon } from '@element-plus/icons-vue'
import { ref, watch, defineProps, defineEmits } from "vue"
import { ElInput, ElTable, ElTableColumn } from "element-plus"
const props = defineProps<{ keyword: string; showTable: boolean }>()

const emit = defineEmits<{
    (e: 'update:keyword', val: string): void
    (e: 'selectWord', word: any): void
}>()

const keyword = ref(props.keyword)
const results = ref<any[]>([])
const loading = ref(false)

// 双向绑定 keyword
watch(() => props.keyword, val => {
    if (val !== keyword.value) keyword.value = val
})
watch(keyword, val => {
    emit('update:keyword', val)
})

// 监听输入，自动查询
watch(keyword, async (val) => {
    if (!val) {
        results.value = []
        return
    }
    loading.value = true
    try {
        const res = await fetch(`http://localhost:5200/api/search?kw=${encodeURIComponent(val)}`)
        results.value = await res.json()
    } catch (e) {
        results.value = []
    }
    loading.value = false
})

// 选中单词
function selectWord(word: any) {
    emit('selectWord', word)
}
</script>

<template>
    <div class="search-container">
        <el-input :suffix-icon="SearchIcon" size="large" v-model="keyword" style="width: 100%;" placeholder="请输入单词"
            clearable />
        <el-table v-if="results.length && showTable" stripe :data="results"
            style="width: 100%; background: rgba(255,255,255,0.8); " @row-click="selectWord" height="200"
            v-loading="loading">
            <el-table-column prop="word" label="单词" width="120" />
            <el-table-column prop="pos" label="词性" width="80">
                <template #default="scope">
                    {{ Array.isArray(scope.row.pos) ? scope.row.pos.join('/') : scope.row.pos }}
                </template>
            </el-table-column>
            <el-table-column prop="translations" label="释义">
                <template #default="scope">
                    {{ Array.isArray(scope.row.translations) ? scope.row.translations.join('；') : scope.row.translations
                    }}
                </template>
            </el-table-column>
        </el-table>

    </div>
</template>

<style scoped>
.search-container {
    position: absolute;
    width: 100%;
    padding: 18px 12px 24px 12px;
    border-radius: 32px;
    overflow: hidden;
}

.loading {
    padding: 8px;
    color: #888;
}
</style>