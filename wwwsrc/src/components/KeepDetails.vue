<template>
    <div class="KeepDetails">
        <div class="row">
            <!-- <h1>IS THIS WORKING?</h1> -->
            <div class="col-4 mt-5" v-for="keep in keeps" :key="keep.id">
                <h3>{{keep.name}}</h3>
                <h4>Description: {{keep.description}}</h4>
                <div><img :src="keep.img"></div>
                <h4>Views: {{keep.views}}</h4>
                <button class=" btn btn-warning"><p>View</p></button>
                <button class=" btn btn-warning"><p>Share</p></button>
                <button class=" btn btn-warning"><p>Keep</p></button>
                <!-- <img :src="keep.image"> -->
                <!-- <button v-if="user.id == keep.userId" class="btn btn-danger" @click="deleteKeep(keep.id)">Delete</button> -->
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
                    img: ""
                }
            }
        },
        computed: {
            User() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.keeps
            }

        },
        methods: {
            deleteKeep(id) {
                this.$store.dispatch('deleteKeep', id)
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