<template>
    <div class="KeepDetails">
        <div class="row">
            <!-- <h1>IS THIS WORKING?</h1> -->
            <div class="col-4 mt-5" v-for="keep in keeps" :key="keep.id">
                <div><img :src="keep.img"></div>
                <h3>{{keep.name}}</h3>
                <h4>Description: {{keep.description}}</h4>
                <h4>Views: {{keep.views}}</h4>
                <button class="btn btn-warning mr-2"><h4>View</h4></button>
                <button class="btn btn-warning mr-2"><h4>Share</h4></button>
                <button class="btn btn-warning"><h4>Keep</h4></button>
                <!-- <img :src="keep.image"> -->
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
                    userId:""
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
            deleteKeep(id) {
                this.$store.dispatch('deleteKeep',id)
            },
            getKeeps(){
                this.$store.dispatch('getKeeps')
            }
        }
    }
</script>
<style scoped>
h3,h4,p {
    font-family: 'Oregano', cursive;
    color:white;
}
</style>