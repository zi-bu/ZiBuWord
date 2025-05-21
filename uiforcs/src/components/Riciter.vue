<script setup>
import Background from './Background.vue';
import { onMounted, ref } from 'vue';

const accurateWord = ref('');
const selection = ref([]);
const selectionWord = ref([]);
const buttonStatus = ref([null, null, null, null]); // 用于存储按钮的状态
const isFinished = ref(false); // 用于判断是否完成

async function fetchContent() {
  const response = await fetch('http://localhost:5200/api/RiciterWord/selection');
  const data = await response.json();
  isFinished.value = !!data.finished;

  if (!isFinished.value && data.accurateWord && data.selection) {
    accurateWord.value = data.accurateWord;
    // 直接赋值整个 selection 数组
    selection.value = data.selection;
    selectionWord.value = data.selection.map(item => item.word);
  }
}
//内容抓取监听
function choice(i) {
  const isRight = accurateWord.value === selectionWord.value[i];
  buttonStatus.value[i] = isRight ? 'right' : 'wrong';
  if (!isRight) {
    const rightIdx = selectionWord.value.findIndex(word => word === accurateWord.value);
    if (rightIdx !== -1) {
      buttonStatus.value[rightIdx] = 'right';
    }
  }
  setTimeout(() => {
    const requestBody = {
      result: isRight
    };
    fetch('http://localhost:5200/api/RiciterWord/Event', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(requestBody)
    })
      .then(res => res.json())
      .then(data => {
        // 重置按钮状态并刷新内容
        buttonStatus.value = [null, null, null, null];
        fetchContent();
      })
      .catch(error => {
        console.error('请求失败:', error);
      });
  }, 800); // 0.8s动画后刷新
}//选项正误判断
function startNewList() {
  fetch('http://localhost:5200/api/RiciterWord/NewList', {
    method: 'POST'
  }).then(() => {
    fetchContent();
  });
}//开始新队列
onMounted(() => {
  fetchContent();
})
</script>

<template>
  <div id="Box">
    <Background />
    <div v-if="!isFinished" class="main-panel">
      <div id="Content">
        <h1 id="Word">{{ accurateWord }}</h1>
      </div>
      <div v-for="(item, idx) in selection" :key="idx" id="Selection" class="card">
        <button class="btn btn-light" :class="buttonStatus[idx]" @click="choice(idx)">
          <!-- 这里嵌入 span，循环显示所有词性和释义 -->
          <span v-for="(p, i) in item.pos" :key="i">
            {{ p }}.{{ item.translations[i] }}&nbsp;
          </span>
        </button>
      </div>
    </div>
    <div v-else class="finish-panel">
      <button @click="startNewList">开始新的队列</button>
      <button @click="goBack">回到主界面</button>
    </div>
  </div>
</template>

<style scoped>
#Box {
  margin: 0 auto;
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  top: 0;
  width: 600px;
  height: 800px;
  margin: 0;
  border-radius: 32px;
  /* 圆角 */
  overflow: hidden;
  /* 防止内容溢出圆角外 */

}

.main-panel {
  margin: 0 auto;
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  top: 0;
  width: 600px;
  height: 800px;
  margin: 0;
}

#Content {
  position: relative;
  display: grid;
  width: 85%;
  height: 15%;
  margin: auto;
  top: 10%;
  border: 0;

}

#Content h1 {
  text-align: center;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: auto;
  color: white;
  font-weight: bold;
  font-style: inherit;
  font-size: 40px;
  text-shadow: 0 0 8px rgba(0, 0, 0, 1);
}

#Selection {
  position: relative;
  display: inline-grid;
  width: 85%;
  height: 10%;
  margin: auto;
  top: 25%;
  left: 50%;
  transform: translate(-50%, -75%);
  background: rgba(255, 255, 255, 0);
  padding: 60px 0;
  border: 0;
}

#Selection button {
  position: absolute;
  width: 100%;
  height: 100%;
  margin: 0%;
  color: white;
  font-weight: bold;
  font-size: 20px;
  background: rgba(255, 255, 255, 0.5);
  text-shadow: 0 0 8px rgba(0, 0, 0, 1);
  text-align: left;
  border: 0;
}

#Selection button:hover {
  position: absolute;
  width: 100%;
  height: 100%;
  margin: 0%;
  color: white;
  font-weight: bold;
  font-size: 20px;
  background: rgba(83, 113, 232, 0.432);
  text-shadow: 0 0 8px rgb(18, 168, 255);
  text-align: left;
  border: 0;
}

#Selection button.right {
  background: rgba(0, 200, 0, 0.7) !important;
}

#Selection button.wrong {
  background: rgba(200, 0, 0, 0.7) !important;
}

.finish-panel {
  position: absolute;
  top: 50%;
  left: 50%;
  width: 100%;
  transform: translate(-50%, -50%);
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 30px;
  z-index: 10;
  background: none;
}

.finish-panel button {
  width: 200px;
  height: 50px;
  font-size: 20px;
  margin: 10px 0;
  background: #ffffffab;
  color: #946ea4;
  font-weight: bold;
  border: none;
  border-radius: 8px;
  transition: background 0.2s;
}

.finish-panel button:hover {
  background: #9377fce8;
  color: #fff;
  text-shadow:
    0 0 8px #12a8ff,
    0 0 16px #12a8ff,
    0 0 24px #12a8ff,
    0 0 32px #12a8ff;
  font-weight: bold;
}
</style>