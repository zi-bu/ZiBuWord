<script setup lang="ts">
import { defineEmits, ref, onMounted, computed } from 'vue'
import { useMouse } from '@vueuse/core'
const emit = defineEmits(['panelClick'])
const isExpanding = ref(false) // 控制扩展动画
const isTitleFading = ref(false); // 控制标题淡出

const containerRef = ref(null)

function useContainerMouse() {
    const { x, y } = useMouse()
    const relativeX = computed(() => {
        const rect = containerRef.value?.getBoundingClientRect()
        return rect ? x.value - rect.left : 0
    })
    const relativeY = computed(() => {
        const rect = containerRef.value?.getBoundingClientRect()
        return rect ? y.value - rect.top : 0
    })
    return { relativeX, relativeY }
}

const { relativeX, relativeY } = useContainerMouse()
const centerX = 300 // 容器宽度一半
const centerY = 400 // 容器高度一半
const maxOffset = 1 // 最大平移像素，可根据需要调整

const offsetX = computed(() => -((relativeX.value - centerX) / centerX) * maxOffset)
const offsetY = computed(() => -((relativeY.value - centerY) / centerY) * maxOffset)
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
    <div class="container" ref="containerRef" :style="{
        backgroundSize: '110% 110%',
        backgroundPosition: 'center',
        transition: 'transform 0.3s cubic-bezier(.4,2.3,.3,1)',
        transform: `translate(${offsetX}px, ${offsetY}px)`
    }">
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
    overflow: hidden;
    background: #fff;
    margin: 0;
    gap: 10px;
    border-radius: 32px;
}

/* 面板基础样式 */
.panel {
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    height: 100%;
    /* 填满容器高度 */
    border-radius: 50px;
    color: #fff;
    cursor: pointer;
    flex: 0.5;
    z-index: 1;
    position: relative;
    transition:
        all 500ms cubic-bezier(.4, 2.3, .3, 1),
        filter 0.5s;

    /* 默认模糊 */
    margin: 0;
    /* 确保无外边距 */
    padding: 0;
    /* 确保无内边距 */
}

.panel::after {
    content: "";
    position: absolute;
    inset: 0;
    background: inherit;
    background-image: inherit;
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    z-index: 0;
    filter: blur(4px);
    transition: filter 0.5s;
    pointer-events: none;
}

/* 激活面板样式（清晰） */
.panel.active {
    flex: 5;
    filter: blur(0);
}

.panel.active::after {
    filter: blur(0);
}

/* 非激活面板始终模糊 */

.panel.blurred::after {
    filter: blur(4px);
}

.panel.expand-anim::after {
    filter: blur(4px);
}

/* 激活面板切换页面前的模糊动画 */
.panel.active-blur {
    filter: blur(4px) !important;
    transition: filter 0.5s;
}

.panel.blurred::after {
    filter: blur(4px);
}

.panel.expand-anim::after {
    filter: blur(4px);
}

/* 标题样式 */
.panel h3 {
    z-index: 1;
    font-size: 24px;
    position: absolute;
    bottom: 20px;
    left: 20px;
    margin: 0;
    opacity: 0;
    transition: opacity 0.3s ease-in 0.4s;
    writing-mode: horizontal-tb;
    /* 默认横排 */
    text-shadow:
        0 0 8px rgba(0, 0, 0, 1),
        0 0 16px rgba(0, 0, 0, 0.8),
        0 2px 4px rgba(0, 0, 0, 0.6),
        0 4px 8px rgba(0, 0, 0, 0.4);
}

.panel.active h3 {
    opacity: 1;
    font-size: 46px;
    writing-mode: horizontal-tb;
    left: 20px;
    bottom: 20px;
    transition: opacity 0.3s ease-in 0.4s, font-size 0.3s;
}

.panel:not(.active) h3,
.panel.blurred h3 {

    opacity: 1;
    font-size: 18px;
    writing-mode: vertical-rl;
    /* 竖排显示 */
    left: 50%;
    bottom: 20px;
    transform: translateX(-50%);
    letter-spacing: 2px;
    text-align: center;
    transition: opacity 0.3s, font-size 0.3s, writing-mode 0.3s;
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
    /* filter: blur(4px);  // ← 删除这一行！ */
}

/* 只让背景模糊 */
.panel.expand-anim::after {
    filter: blur(4px);
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
    font-size: 46px;
    text-shadow:
        0 0 8px rgba(0, 0, 0, 1),
        0 0 16px rgba(0, 0, 0, 0.8),
        0 2px 4px rgba(0, 0, 0, 0.6),
        0 4px 8px rgba(0, 0, 0, 0.4);
}
</style>