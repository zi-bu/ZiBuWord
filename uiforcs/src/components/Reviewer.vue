﻿<script setup>

import { defineEmits } from 'vue'
import { onMounted, ref, computed } from "vue";
import { useMouse } from "@vueuse/core";
import {Back, Star} from '@element-plus/icons-vue'

const emit = defineEmits(['panelClick'])

function goBack() {
  emit('panelClick', 'Mainpage')
}

const centerX = 300 // 容器宽度一半
const centerY = 400 // 容器高度一半
const maxOffset = 1 // 最大平移像素，可根据需要调整

const offsetX = computed(() => -((relativeX.value - centerX) / centerX) * maxOffset)
const offsetY = computed(() => -((relativeY.value - centerY) / centerY) * maxOffset)


const containerRef = ref(null)

const maskPosition = computed(() => `${relativeX.value - 300}px ${relativeY.value - 400}px`);
const word = ref('');
const info = ref('');
const showInfo = ref(false);
const showButton = ref(true);
const listCount = ref(1);
const { relativeX, relativeY } = useContainerMouse()

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

async function fetchWord() {
  const response = await fetch('http://localhost:5200/api/ReviewWord');
  const data = await response.json();
  word.value = data.wordOfReview;
  info.value = data.infoOfReview;
  showInfo.value = false;
  showButton.value = true;

}


async function fetchWordListCount() {
  const response = await fetch('http://localhost:5200/api/ReviewWord/wordListCount');
  const data = await response.json();
  listCount.value = data.wordListCount;
}

onMounted(() => {
  fetchWord();
  fetchWordListCount();
});

function toggleInfo() {
  showInfo.value = !showInfo.value;
  showButton.value = !showButton.value;
}
//是的按钮触发事件
function chooseYes() {
  toggleInfo();
  fetch('http://localhost:5200/api/ReviewWord/EventYes', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({})
  })
    .then(res => res.json())
    .then(data => {
      // 处理返回数据
      console.log(data);
    });
  fetchWordListCount();
  showCondition();
}
function chooseNo() {
  toggleInfo();
  fetch('http://localhost:5200/api/ReviewWord/EventNo', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json'
    },
    body: JSON.stringify({})
  })
    .then(res => res.json())
    .then(data => {
      // 处理返回数据
      console.log(data);
    });
  fetchWordListCount();
  showCondition();
}

function Next() {
  toggleInfo();
  fetchWord();
  fetchWordListCount();
}
</script>

<template>
  <div class="Container">
    <div ref="containerRef" id="reviewer" class="card" :style="{
      backgroundSize: '110% 110%',
      backgroundPosition: 'center',
      transition: 'transform 0.3s cubic-bezier(.4,2.3,.3,1)',
      transform: `translate(${offsetX}px, ${offsetY}px)`
    }">

      <div class="background-clear"></div>
      <div class="background"></div>

      <div class="back-btn-pos">
        <el-button circle size="large" @click="goBack">
          <el-icon>
            <Back />
          </el-icon>
        </el-button>
        <el-button circle size="large">
          <el-icon>
            <Star />
          </el-icon>
        </el-button>
      </div>
      <div v-show="listCount !== 0" id="reviewerInside">
        <h1 class="card-title">{{ word }}</h1>
        <div id="infoContainer" class="card">

          <pre v-if="showInfo" id="info">{{ info }}</pre>

        </div>
        <div>
          <button v-if="showButton" id="define-btn" class="btn btn-light" type="button" @click="chooseYes">
            认识
          </button>
          <button v-if="showButton" id="define-btn" class="btn btn-light" type="button" @click="chooseNo">
            不认识
          </button>
          <button v-if="!showButton" id="next-btn" class="btn btn-light" type="button" @click="Next">
            下一个
          </button>
        </div>
      </div>


      <div v-show="listCount === 0" id="overcard" class="card">
        <p>本队列单词复习完毕</p>

      </div>
      <div>
        <button @click="Next" v-show="listCount === 0" class="btn btn-light zindex-2 Overbtn1"
          id="define-btn">开始下一个队列</button>

      </div>






    </div>
  </div>
</template>

<style scoped>
.back-btn-pos {
  position: absolute;
  top: 10px;
  left: 10px;
  /* 只定位外层div，不影响el-button动画 */
  z-index: 10;
}



#dot {
  position: absolute;
  top: v-bind(mouseY)px;
  left: v-bind(mouseX)px;
  background: url('/img/background/7.jpg') center/cover no-repeat;
  filter: blur(0px);
  z-index: 0;

}

#define-btn {
  height: 60px;
  width: 225px;
  margin-bottom: 50px;
  margin-top: 20px;
  font-weight: bold;
  background: rgba(255, 255, 255, 0.778);
}

#define-btn:hover {
  background: rgba(235, 148, 213, 0.778);
  text-shadow: #b0e5d7bc 0px 0px 8px;
  color: rgb(255, 255, 255);
}

#define-btn,
#next-btn {
  border: none;
  /* 去除边框 */
  box-shadow: none;
  /* 去除阴影 */
  outline: none;
  /* 去除点击后的外边框 */
}

#YES-btn:hover,
#next-btn:hover {
  background-color: #39bc3de1;
  /* 绿色 */
  color: rgb(255, 255, 255);
  text-shadow: pink 0px 0px 8px;
  /*noinspection CssInvalidPropertyValue*/
  transition: background-color 0.2;
}

#next-btn {
  height: 60px;
  width: 450px;
  margin-bottom: 50px;
  margin-top: 20px;
  font-weight: bold;
  background: rgba(255, 255, 255, 0.778);
}

.Container {
  #reviewer {
    margin: 0 0;
    position: absolute;
    bottom: 0;
    left: 0;
    right: 0;
    top: 0;
    height: 800px;
    width: 600px;
    color: black;


    z-index: 0;
  }
}

#reviewer {
  margin: 0 0;
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  top: 0;
  height: 800px;
  width: 600px;
  color: black;


  z-index: 0;
}

.background {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: url('/img/background/7.jpg') center/cover no-repeat;
  filter: blur(4px);
  z-index: -2;
  background-color: rgba(0, 0, 0, 0.4);
}

.background-clear {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: url('/img/background/7.jpg') center/cover no-repeat;
  filter: blur(0px);
  z-index: -1;
  mask-image: radial-gradient(circle at center, white 40%, black 70%);
  mask-repeat: no-repeat;
  mask-mode: luminance;
  mask-size: 100%;
  mask-position: v-bind(maskPosition);
  background-color: rgba(0, 0, 0, 0.2);
  -webkit-mask-clip: stroke-box;
  mask-clip: stroke-box;
  -webkit-mask-origin: border-box;
  mask-origin: border-box;
}

#reviewerInside {
  position: relative;
  z-index: 1;
  height: 800px;
  width: 600px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
}

#reviewer h1 {
  margin-top: 100px;
  color: white;
  font-weight: bold;
  font-size: 48px;
  text-shadow: 0 0 8px rgba(0, 0, 0, 1);
}

#infoContainer {
  background-color: rgba(255, 255, 255, 0.64);
  height: 450px;
  width: 450px;
  margin-top: 40px;
  margin-bottom: 10px;
}

#infoContainer pre {
  margin-left: 10px;
  margin-top: 5px;
}

#overcard {
  height: 60px;
  width: 450px;
  color: black;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: rgba(255, 255, 255, 0.64);
}

#overcard p {
  margin-left: 10px;
  margin-top: 15px;
  font-weight: bold;
}

.Overbtn1 {
  position: absolute;
  display: block;
  top: 60%;
  left: 50%;
  transform: translate(-50%, -50%);
}

.Overbtn2 {
  position: absolute;
  display: block;
  top: 70%;
  left: 30%;
  transform: translate(-50%, -50%);
}

#info {
  font-size: 18px;
}

.zindex-2 {
  z-index: 2;
}
</style>

