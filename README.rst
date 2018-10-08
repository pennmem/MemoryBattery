MemoryBattery
=============

.. image:: https://img.shields.io/travis/leondavis1/memorybattery.svg
   :target: https://travis-ci.org/leondavis1/memorybattery

.. image:: https://codecov.io/gh/leondavis1/memorybattery/branch/master/graph/badge.svg
   :target: https://codecov.io/gh/leondavis1/memorybattery

.. image:: https://img.shields.io/badge/docs-here-brightgreen.svg
   :target: https://pennmem.github.io/leondavis1/memorybattery/html/index.html
   :alt: docs

A recall-based neuropsych battery in Unity



To add a task to the battery
----------------------------
- Have the main script in your task inherit from `Experiment.Experiment`, which requires implementing RunList() as a coroutine;
- Add the `ExperimentPipeline` asset to your main script
- Add the name of the scene containing your task to <<LIST_OF_TASKS_TBD>>
- That's it!