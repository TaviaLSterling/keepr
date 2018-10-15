<template>
    <div class="KeepDetails">
        <div class="row">
            <!-- <h1>IS THIS WORKING?</h1> -->
            <div class="col-4 mt-5" v-for="keep in keeps" :key="keep.id" @mouseenter="hoverButtons = true" @mouseleave="hoverButtons = false">
                <h3>{{keep.name}}</h3>
                <div class="image"><img :src="keep.img"></div>
                <h4>Description: {{keep.description}}</h4>
                <h4>Views: {{keep.views}}</h4>
                <h4>Keeps:{{keep.keeps}}</h4>
                <!-- make buttons appear if hovering -->
                <div v-if="hoverButtons = hoverButtons ? true: false">
                    <button class="btn btn-warning mr-2" @click="viewKeep(keep)">
                        <h4>View</h4>
                    </button>
                    <button class="btn btn-warning mr-2">
                        <h4>Share</h4>
                    </button>
                    <!-- <button class="btn btn-warning" @click="saveKeep(keep)">
                        <h4>Keep</h4>
                    </button> -->
                </div>
                <button v-if="user.id == keep.userId" class="btn btn-info ml-2" @click="editKeep(keep.id)">Edit</button>
                <button v-if="user.id == keep.userId" class="btn btn-danger ml-2" @click="deleteKeep(keep.id)">Delete</button>

                <form @submit.prevent>
                    <select class="options" v-model="pickVault">
                        <option diabled value="">Vaults:</option>
                        <option v-for="vault in vaults" v-bind:value="vault.id">{{vault.name}}</option>
                    </select>
                    <button class="btn btn-success m-2" type="submit" @click="savedVaultKeep(keep)">Keep</button>
                </form>
            </div>
        </div>
    </div>
</template>


<script>
    export default {
        name: 'KeepDetails',
        data() {
            return {
                hoverButtons: false,
                keep: {
                    name: "",
                    description: "",
                    img: "",
                    userId: ""
                },
                vault: {
                    name: "",
                    description: "",
                    userId: ""
                },
                vaultKeep: {
                    vaultId: "",
                    keepId: "",
                    userId: ""
                },
                pickVault: ""
            }
        },
        mounted() {
            this.$store.dispatch("getVaults");
            // this.$store.dispatch("getVaultKeeps")
        },
        computed: {
            user() {
                return this.$store.state.user
            },
            keeps() {
                return this.$store.state.keeps
            },
            vaults() {
                return this.$store.state.vaults;
            },
            vaultKeeps() {
                return this.$store.state.vaultKeeps;
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
            },
            savedVaultKeep(keep) {
                keep.keeps++
                this.vaultKeep.userId = this.user.id
                this.vaultKeep.keepId = keep.id
                this.vaultKeep.vaultId = this.pickVault
                this.$store.dispatch("savedVaultKeep", this.vaultKeep);
            
            },
        }
    }
</script>
<style scoped>
    h3,
    h4,
    p,
        {
        font-family: 'Oregano', cursive;
        color: white;
    }

    .btn,
    .KeepDetails {
        font-family: 'Oregano', cursive;
        color: white;

    }

    .image {
        position: relative;
    }
    .image .btn {
  position: absolute;
    }
</style>