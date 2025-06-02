<script lang="ts" setup>
import { ref, watch } from "vue"
import {Back, Star} from '@element-plus/icons-vue'
import Search from "./Search.vue"
import BackgroundFindUrWords from "./BackgroundFindUrWords.vue"
import WordCard from "./WordCard.vue"
const showTable = ref(true)
const emit = defineEmits<{
    (e: 'panelClick', page: string): void
}>()

const keyword = ref<string>("")
const selectedWord = ref<any>(null)

function goBack() {
    emit('panelClick', 'Mainpage')
}


function handleSelectWord(word: any) {
    keyword.value = word.word
    selectedWord.value = word
    showTable.value = false // 隐藏表格
}
// 输入变化时清除卡片
watch(keyword, () => {
    selectedWord.value = null
    showTable.value = true // 输入变化时重新显示表格
})
</script>

<template>
    <div class="Container">
        <BackgroundFindUrWords />
        <div class="main-panel">
            <div class="top-bar">
                <div class="back-btn-pos">
                    <el-button circle size="large" @click="goBack">
                        <el-icon>
                            <Back />
                        </el-icon>
                    </el-button>
                </div>
                <div class="search-bar-wrap">
                    <Search v-model:keyword="keyword" @selectWord="handleSelectWord" :show-table="showTable" />
                </div>
            </div>
            <div class="Card-wrap">
                <WordCard v-if="selectedWord" :word="selectedWord" class="full-card" />
            </div>
        </div>
    </div>
</template>
<style scoped>
.Container {
    display: flex;
    width: 600px;
    height: 800px;
    position: fixed;
    top: 0;
    left: 0;
    overflow: hidden;
    margin: 0;
    gap: 10px;
    border-radius: 32px;
}

.back-btn-pos {
    position: absolute;
    top: 740px;
    left: 20px;
    z-index: 10;
}

.Card-wrap {

    position: absolute;
    left: 50%;
    top: 70px;
    transform: translateX(-50%);
    width: 550px;
    height: 650px;
    z-index: 10;
}

.full-card {
    width: 100%;
    height: 100%;
    box-sizing: border-box;
}

.main-panel {
    margin: 0 0;
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    top: 0;
    width: 600px;
    height: 800px;
}
</style>