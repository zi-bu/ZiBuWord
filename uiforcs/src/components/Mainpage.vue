<script setup lang="ts">
import { defineEmits, ref } from 'vue'
import BackgroundMain from './Background - Main.vue'
const emit = defineEmits(['panelClick'])
const isExpanding = ref(false) // 控制扩展动画
const isTitleFading = ref(false); // 控制标题淡出
// 面板数据
const panels = ref([
    { title: 'StartToLearn', bg: "/img/background/bg-Recite.jpg" },
    { title: 'ReviewTime', bg: "/img/background/bg-Review.jpg" },
    { title: 'FindUrWords', bg: "/img/background/bg-Select.jpg" },
    { title: 'UrFavorite', bg: "/img/background/bg-Favorites.jpg" },
])

const activeIndex = ref<number>(0) // 当前激活面板
const isActiveBlur = ref(false)    // 控制激活面板切换前的模糊动画

// 点击面板逻辑
function handlePanelClick(idx: number) {
    if (activeIndex.value !== idx) {
        activeIndex.value = idx
        isActiveBlur.value = false
        isExpanding.value = false
        isTitleFading.value = false
    } else {
        isActiveBlur.value = true
        setTimeout(() => {
            isActiveBlur.value = false
            isExpanding.value = true
            isTitleFading.value = false
            // 先扩展，动画快结束时再让标题淡出
            setTimeout(() => {
                isTitleFading.value = true
            }, 400) // 标题在扩展动画后400ms开始淡出（可调整）
            setTimeout(() => {
                emit('panelClick', panels.value[idx].title)
                isExpanding.value = false
                isTitleFading.value = false
            }, 600) // 扩展动画总时长
        }, 300) // 模糊动画持续时间
    }
}
</script>

<template>
    <div class="container">
        <div v-for="(panel, idx) in panels" :key="panel.title" class="panel" :class="{
            active: idx === activeIndex,
            'blurred': idx !== activeIndex,
            'active-blur': idx === activeIndex && isActiveBlur,
            'expand-anim': idx === activeIndex && isExpanding
        }" :style="{ backgroundImage: `url('${panel.bg}')` }" @click="handlePanelClick(idx)">
            <h3 :class="{ 'fade-out': idx === activeIndex && isTitleFading }">{{ panel.title }}</h3>
        </div>
    </div>
</template>

<style scoped>
.container {
    display: flex;
    width: 600px;
    height: 800px;
    position: fixed;
    top: 0;
    left: 0;
    transform: none;
    overflow: hidden;
    background: transparent;
    margin: 0;
    gap: 10px;
    border-radius: 32px;
    /* 圆角 */
    overflow: hidden;
    /* 防止内容溢出圆角外 */
    background: #fff;
    /* 可选，设置背景色更明显 */
}

/* 面板基础样式 */
.panel {
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    height: 80vh;
    border-radius: 50px;
    color: #fff;
    cursor: pointer;
    flex: 0.5;
    z-index: 1;
    position: relative;
    transition:
        all 500ms cubic-bezier(.4, 2.3, .3, 1),
        filter 0.5s;
    filter: blur(4px);
    /* 默认模糊 */
}

/* 激活面板样式（清晰） */
.panel.active {
    flex: 5;
    filter: blur(0);
}

/* 非激活面板始终模糊 */
.panel.blurred {
    filter: blur(4px);
}

/* 激活面板切换页面前的模糊动画 */
.panel.active-blur {
    filter: blur(4px) !important;
    transition: filter 0.5s;
}

/* 标题样式 */
.panel h3 {
    font-size: 24px;
    position: absolute;
    bottom: 20px;
    left: 20px;
    margin: 0;
    opacity: 0;
    transition: opacity 0.3s ease-in 0.4s;
}

.panel.active h3 {
    opacity: 1;
    transition: opacity 0.3s ease-in 0.4s;
}

/* 展开动画（可选） */
.panel.expand-anim {
    position: absolute;
    top: 0;
    left: 0;
    width: 600px;
    height: 800px;
    border-radius: 0;
    flex: none !important;
    z-index: 999;
    transition: all 0.6s cubic-bezier(.4, 2.3, .3, 1);
    filter: blur(4px);
    /* 关键：扩展时图片模糊 */
}

.panel.expand-anim h3 {
    opacity: 1;
    /* 扩展时先保持可见 */
    transition: opacity 0.2s linear;
}

.panel.expand-anim h3.fade-out {
    opacity: 0;
    transition: opacity 0.2s linear;
}

@media (max-width: 480px) {
    .container {
        width: 100vw;
    }

    .panel:nth-of-type(4),
    .panel:nth-of-type(5) {
        display: none;
    }
}

.container div h3 {
    font-weight: bold;
    font-size: 32px;
    text-shadow:
        0 0 8px rgba(0, 0, 0, 1),
        0 0 16px rgba(0, 0, 0, 0.8),
        0 2px 4px rgba(0, 0, 0, 0.6),
        0 4px 8px rgba(0, 0, 0, 0.4);
}
</style>