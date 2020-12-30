
$('.editor').trumbowyg({
    lang: 'ko',
    btnsDef: {
        image: {
            dropdown: ['insertImage', 'upload'], //기존 insertImage를 upload로 변경
            ico:'insertImage'
        }
    },
    btns: [
        ['viewHTML'],
   //     ['undo', 'redo'], // Only supported in Blink browsers
        ['formatting'],
        ['strong', 'em', 'del'],
        ['superscript', 'subscript'],
        ['link'],
        'image',
        ['justifyLeft', 'justifyCenter', 'justifyRight', 'justifyFull'],
        ['unorderedList', 'orderedList'],
        ['horizontalRule'],
        ['removeformat'],
        ['fullscreen']

    ]
});