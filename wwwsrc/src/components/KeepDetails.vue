<template>
    <div class="KeepDetails">
        <div class="row">
            <!-- <h1>IS THIS WORKING?</h1> -->
            <div class="col-4 mt-5" v-for="keep in keeps" :key="keep.id">
                <div><img :src="keep.img"></div>
                <h3>{{keep.name}}</h3>
                <h4>Description: {{keep.description}}</h4>
                <h4>Views: {{keep.views}}</h4>
                <h4>Keeps:{{keep.keeps}}</h4>
                <button class="btn btn-warning mr-2" @click="viewKeep(keep)">
                    <h4>View</h4>
                </button>
                <button class="btn btn-warning mr-2">
                    <h4>Share</h4>
                </button>
                <button class="btn btn-warning" @click="saveKeep(keep)">
                    <h4>Keep</h4>
                </button>
                <button v-if="user.id == keep.userId" class="btn btn-info ml-2" @click="editKeep(keep.id)">Edit</button>
                <button v-if="user.id == keep.userId" class="btn btn-danger ml-2" @click="deleteKeep(keep.id)">Delete</button>
            </div>
        </div>
    </div>
</template>


<script>
    export default {
        name: 'KeepDetails',
        data() {
            return {
                keep: {
                    name: "",
                    description: "",
                    img: "",
                    userId: ""
                }
            }
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.keeps
            }

        },
        methods: {
            deleteKeep(keep) {
                if (keep.userId == this.user.id) {
                    this.$store.dispatch("deleteKeep", keep);
                }
            },
            deleteKeep(keepId) {
                this.$store.dispatch('deleteKeep', keepId)
            },
            getKeeps() {
                this.$store.dispatch('getKeeps')
            },
            viewKeep(keep) {
                keep.views++
            },
            saveKeep(keep) {
                this.$store.dispatch("saveKeep", keep)
                keep.keeps++
            },
            editKeep(id) {
                this.$store.dispatch('editKeep', id)
            }
        }
    }
</script>
<style scoped>
    h3,
    h4,
    p {
        font-family: 'Oregano', cursive;
        color: white;
    }

    .btn {
        font-family: 'Oregano', cursive;
        color: white;

    }
</style>