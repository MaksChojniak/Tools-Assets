const contentMap = {
    "About":     `<h1 class="content-title">About Console</h1>
                     <p class="content-normal">Something about console!</p>`,
    "Donation":     `<h1 class="content-title">Donation</h1>
                     <p class="content-normal">Support us by donating!</p>`,
    "Contact":      `<h1 class="content-title">Contact</h1>
                     <p class="content-normal">Contact us at example@email.com.</p>`,
    "Logging Types":`<h1 class="content-title">Logging Types</h1>
                     <p class="content-normal">Information about logging types.</p>`,
    "Basic Commands":`<h1 class="content-title">Basic Commands</h1>
                     <p class="content-normal">List of basic commands.</p>`,
    "Own Commands": `<h1 class="content-title">Own Commands</h1>
                     <p class="content-normal">Your own custom commands.</p>`,
    "Console":      `<h1 class="content-title">Console</h1>
                     <p class="content-normal">Console section overview.</p>`,
    "Default":      `<h1 class="content-title">Default</h1>
                     <p class="content-normal">this is default menu.</p>
                     <ul class="content-normal">
                        <li>First item</li>
                        <li>Second item</li>
                        <li>Third item</li>
                    </ul>`
};

function updateMainContent(section) {
    if (contentMap[section]) {
        document.querySelector('main.content').innerHTML = contentMap[section];
    }
}



updateMainContent("Default")

document.querySelectorAll('.sidebar-section-title, .sidebar-subsection-title').forEach(link => {
    link.addEventListener('click', function(e) {
        const section = this.textContent.trim();
        updateMainContent(section);
        if (contentMap[section]) {
            e.preventDefault();
        }
    });
});