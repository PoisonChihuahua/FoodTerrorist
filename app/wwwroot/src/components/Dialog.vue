<template>
    <v-app>
        <v-dialog
            v-model="dialog"
            persistent
            max-width="290"
        >
            <template v-slot:activator="{ on, attrs }">
                <v-btn
                    color="primary"
                    dark
                    v-bind="attrs"
                    v-on="on"
                >
                    Open Dialog
                </v-btn>
            </template>
            <v-card>
                <v-card-title class="headline">
                    本当に実行しますか？
                </v-card-title>
                <v-card-text>内容</v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn @click="dialog = false">
                        取り消し
                    </v-btn>
                    <v-btn @click="dialog = false">
                        確認
                    </v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-app>
</template>

<script>
export default {
    data () {
        return {
            dialog: false,
        }
    }
}
</script>