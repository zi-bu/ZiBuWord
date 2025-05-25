<script lang="ts" setup>
import { ElCard } from "element-plus"
const props = defineProps<{
    word: {
        word: string
        pos?: string[]
        translations?: string[]
        phrases?: string[]
        phraseTranslations?: string[]
    }
}>()
</script>

<template>
    <el-card class="word-card" :body-style="{ height: '100%', background: '#fafaffcd' }">
        <h3>{{ word.word }}</h3>
        <p>词性：{{ word.pos?.join('/') }}</p>
        <p>释义：{{ word.translations?.join('；') }}</p>
        <div v-if="word.phrases && word.phraseTranslations && word.phrases.length">
            <h4>常用短语：</h4>
            <ul>
                <li v-for="(phrase, idx) in word.phrases" :key="idx">
                    <span>{{ phrase }}</span>
                    <span v-if="word.phraseTranslations && word.phraseTranslations[idx]">
                        ：{{ word.phraseTranslations[idx] }}
                    </span>
                </li>
            </ul>
        </div>
    </el-card>
</template>

<style scoped>
.word-card {
    width: 100%;
    height: 100%;
    border-radius: 10px;
    font-weight: bold;
    font-size: 22px;
    box-sizing: border-box;
    display: flex;
    flex-direction: column;
    justify-content: flex-start;
    margin: 0;
    padding: 0;
}

.word-card h3 {
    margin: 0 0 12px 0;
}

.word-card h4 {
    margin: 18px 0 8px 0;
    font-size: 18px;
    font-weight: bold;
}

.word-card ul {
    padding-left: 20px;
    margin: 0;
}

.word-card li {
    font-size: 18px;
    margin-bottom: 6px;
    list-style: disc;
    font-weight: normal;
}
</style>